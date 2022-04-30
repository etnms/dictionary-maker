using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;
using System.Xml.Serialization;

namespace Dictionary_Maker
{
    // In language settings -> lot of ifs are used, a switch statement would be much more appropriate and efficient
    public partial class MainWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public string userfile;
       

        public MainWindow()
        {
           
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Shortcuts();
            dgWords.ItemsSource = items;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dgWords.ItemsSource);
            view.Filter = WordFilter;
            LoadLanguageSettings();
            LoadPronunciationSetting();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            openFileDialog.Title = openfile;
            if (openFileDialog.ShowDialog() == true)
            {
                items.Clear();
                userfile = openFileDialog.FileName;
                LoadList();
            }
            Title = "Dictionary Maker: " + Path.GetFileNameWithoutExtension(userfile);

        }


        public void NewFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.Title = newfile;
            if (saveFileDialog.ShowDialog() == true)
            {
                userfile = saveFileDialog.FileName; // must be put before xml array in order to have the correct namespace

                string nsdeclaration = "";
                if (Path.GetFileNameWithoutExtension(userfile).Length > 3)
                {
                    nsdeclaration = Path.GetFileNameWithoutExtension(userfile).Remove(3);
                }
                if (Path.GetFileNameWithoutExtension(userfile).Length <= 3)
                {
                    nsdeclaration = Path.GetFileNameWithoutExtension(userfile);
                }
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                //root // defines a namespace for the xml document but this namespace will be updated later (useless to have it here tbh)
                XmlElement array = doc.CreateElement(nsdeclaration, "ArrayWordInDictionnary", Path.GetFileNameWithoutExtension(userfile));
                doc.AppendChild(array);
                doc.Save(saveFileDialog.FileName);

                items.Clear();
                LoadList();
                this.Title = "Dictionary Maker: " + Path.GetFileNameWithoutExtension(userfile);
            }
        }

        private void btnDeleteWord_Click(object sender, RoutedEventArgs e)
        {
            if (userfile != null)
            {
                if (dgWords.SelectedItem == null)
                {
                    LoadErrorWindowSelection();
                }
                if (dgWords.SelectedItem != null)
                {
                    items.Remove(dgWords.SelectedItem as WordInDictionary);

                    //prepare namespace for serialization (or else automatic namespace will be added)
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    if (Path.GetFileNameWithoutExtension(userfile).Length > 3)
                    {
                        ns.Add(Path.GetFileNameWithoutExtension(userfile).Remove(3), Path.GetFileNameWithoutExtension(userfile));
                    }
                    if (Path.GetFileNameWithoutExtension(userfile).Length <= 3)
                    {
                        ns.Add(Path.GetFileNameWithoutExtension(userfile), Path.GetFileNameWithoutExtension(userfile));
                    }

                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<WordInDictionary>));
                    using (StreamWriter sw = new StreamWriter(userfile))

                    {
                        xs.Serialize(sw, items, ns);
                    }
                }
            }
        }

        private void btnChangeWord_Click(object sender, RoutedEventArgs e)
        {  
            if (dgWords.SelectedItem == null)
            {
                LoadErrorWindowSelection();
            }

            if (dgWords.SelectedItem != null)
            {
                ChangeWordWindow ChangeWordWindow = new ChangeWordWindow();

                //update the window with the values of the selected item
                ChangeWordWindow.txtChangeWord.Text = (dgWords.SelectedItem as WordInDictionary).Word;
                ChangeWordWindow.txtChangeTranslation.Text = (dgWords.SelectedItem as WordInDictionary).Translation;
                ChangeWordWindow.txtChangeDefinition.Text = (dgWords.SelectedItem as WordInDictionary).Definition;
                ChangeWordWindow.txtChangeExample.Text = (dgWords.SelectedItem as WordInDictionary).Example;
                ChangeWordWindow.ChangeComboBoxPOS.Text = (dgWords.SelectedItem as WordInDictionary).POS;
                ChangeWordWindow.ChangeComboBoxGloss.Text = (dgWords.SelectedItem as WordInDictionary).Gloss;

                //open window dialog to change the word
                ChangeWordWindow.ShowDialog();
                if (ChangeWordWindow.DialogResult == true)
                {

                    // Main changes to the word
                    (dgWords.SelectedItem as WordInDictionary).Word = ChangeWordWindow.txtChangeWord.Text.ToLower();
                    (dgWords.SelectedItem as WordInDictionary).Translation = ChangeWordWindow.txtChangeTranslation.Text.ToLower();
                    (dgWords.SelectedItem as WordInDictionary).Definition = ChangeWordWindow.txtChangeDefinition.Text;
                    (dgWords.SelectedItem as WordInDictionary).Example = ChangeWordWindow.txtChangeExample.Text;
                    (dgWords.SelectedItem as WordInDictionary).POS = ChangeWordWindow.ChangecbPOS();
                    (dgWords.SelectedItem as WordInDictionary).Gloss = ChangeWordWindow.ChangecbGloss();

                    //serialize changes
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); //first making sure the namespace remains the same
                    if (Path.GetFileNameWithoutExtension(userfile).Length > 3)
                    {
                        ns.Add(Path.GetFileNameWithoutExtension(userfile).Remove(3), Path.GetFileNameWithoutExtension(userfile));
                    }
                    if (Path.GetFileNameWithoutExtension(userfile).Length <= 3)
                    {
                        ns.Add(Path.GetFileNameWithoutExtension(userfile), Path.GetFileNameWithoutExtension(userfile));
                    }

                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<WordInDictionary>));
                    using (StreamWriter sw = new StreamWriter(userfile))

                    {
                        xs.Serialize(sw, items, ns);
                    }
                }
            }
        }

        //Search through list option (filtering)
        private bool WordFilter(object item)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (item as WordInDictionary).Word.Contains(txtFilter.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgWords.ItemsSource).Refresh();
        }

        private void Select_Deselect_Click(object sender, RoutedEventArgs e)
        {
            dgWords.SelectedItems.Clear();
            if (dgWords.SelectedItem != null)
            {
                dgWords.UnselectAll();
            }
        }

        private void HidePronunciationColumn(object sender, RoutedEventArgs e)
        {
            

            if (PronunciationMneu.IsChecked == false)
            {
                dgWords.Columns[2].Width = 0;
                dgWords.Columns[2].Visibility = Visibility.Hidden;
                TextBlockPronunciation.Visibility = Visibility.Hidden;
                txtPronunciation.Visibility = Visibility.Hidden;
                Grid.SetRow(TextBlockDefinition, 3);
                Grid.SetRowSpan(TextBlockDefinition, 2);
                Grid.SetRow(txtDefinition, 3);
                Grid.SetRowSpan(txtDefinition, 2);
                Properties.Settings.Default.Pronunciation = false;
                Properties.Settings.Default.Save();
            }
            if (PronunciationMneu.IsChecked == true)
            {
                dgWords.Columns[2].Width = new DataGridLength(1.1, DataGridLengthUnitType.Star);
                dgWords.Columns[2].Visibility = Visibility.Visible;
                TextBlockPronunciation.Visibility = Visibility.Visible;
                txtPronunciation.Visibility = Visibility.Visible;
                Grid.SetRow(TextBlockDefinition, 4);
                Grid.SetRowSpan(TextBlockDefinition, 1);
                Grid.SetRow(txtDefinition, 4);
                Grid.SetRowSpan(txtDefinition, 1);
                Properties.Settings.Default.Pronunciation = true;
                Properties.Settings.Default.Save();
            }

        }

        private void LoadPronunciationSetting()
        {
            if (Properties.Settings.Default.Pronunciation == false)
            {
                PronunciationMneu.IsChecked = false;
                dgWords.Columns[2].Width = 0;
                dgWords.Columns[2].Visibility = Visibility.Hidden;
                TextBlockPronunciation.Visibility = Visibility.Hidden;
                txtPronunciation.Visibility = Visibility.Hidden;
                Grid.SetRow(TextBlockDefinition, 3);
                Grid.SetRowSpan(TextBlockDefinition, 2);
                Grid.SetRow(txtDefinition, 3);
                Grid.SetRowSpan(txtDefinition, 2);

            }
            if (Properties.Settings.Default.Pronunciation == true)
            {
                PronunciationMneu.IsChecked = true;
                dgWords.Columns[2].Width = new DataGridLength(1.1, DataGridLengthUnitType.Star);
                dgWords.Columns[2].Visibility = Visibility.Visible;
                TextBlockPronunciation.Visibility = Visibility.Visible;
                txtPronunciation.Visibility = Visibility.Visible;
                Grid.SetRow(TextBlockDefinition, 4);
                Grid.SetRowSpan(TextBlockDefinition, 1);
                Grid.SetRow(txtDefinition, 4);
                Grid.SetRowSpan(txtDefinition, 1);

            }
        }

    }
}



