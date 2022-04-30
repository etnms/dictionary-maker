using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Xml;

namespace Dictionary_Maker
{
    /// <summary>
    /// Interaction logic for LaunchWindow.xaml
    /// </summary>

    public partial class LaunchWindow : Window
    {
        MainWindow MainWindow = new MainWindow();
        public LaunchWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ComboBoxLanguage();
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.Title = newprojectdialog;
            if (saveFileDialog.ShowDialog() == true)
            {
                MainWindow.userfile = saveFileDialog.FileName; // must be put before xml array in order to have the correct namespace

                string nsdeclaration = "";
                if (Path.GetFileNameWithoutExtension(MainWindow.userfile).Length > 3)
                {
                    nsdeclaration = Path.GetFileNameWithoutExtension(MainWindow.userfile).Remove(3);
                }
                if (Path.GetFileNameWithoutExtension(MainWindow.userfile).Length <= 3)
                {
                    nsdeclaration = Path.GetFileNameWithoutExtension(MainWindow.userfile);
                }
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                //root // defines a namespace for the xml document 
                XmlElement array = doc.CreateElement(nsdeclaration, "ArrayWordInDictionnary", Path.GetFileNameWithoutExtension(MainWindow.userfile));

                doc.AppendChild(array);

                doc.Save(saveFileDialog.FileName);
                MainWindow.userfile = saveFileDialog.FileName;

                MainWindow.items.Clear();
                MainWindow.LoadList();
                MainWindow.Show();
                MainWindow.Title = "Dictionary Maker:" + Path.GetFileNameWithoutExtension(MainWindow.userfile);
                this.Hide();
            }
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            openFileDialog.Title = openprojectdialog;
            if (openFileDialog.ShowDialog() == true)
            {
                MainWindow.items.Clear();
                MainWindow.userfile = openFileDialog.FileName;
                MainWindow.LoadList();
                MainWindow.Show();
                MainWindow.Title = "Dictionary Maker: " + Path.GetFileNameWithoutExtension(MainWindow.userfile);
                this.Hide();
            }
        }

        private void Launchindow_Closing(object sender, CancelEventArgs e)
        { 
            Application.Current.Shutdown();
        }
    }


}
