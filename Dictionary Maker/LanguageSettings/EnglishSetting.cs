using System;
using System.Linq;
using System.Windows;


namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {

        public void Englishunchecked(object sender, RoutedEventArgs e)
        {            
            Properties.Settings.Default.English = englishsetting;
            Properties.Settings.Default.Save();
            LoadEnglishSetting();
        }

        public void Englishchecked(object sender, RoutedEventArgs e)
        {
            englishsetting = true;
            frenchsetting = false;
            spanishsetting = false;
            Properties.Settings.Default.English = englishsetting;
            Properties.Settings.Default.Save();
            LoadEnglishSetting();
        }

        public void LoadEnglishSetting()
        {
            //ErrorWindow ErrorWindow = new ErrorWindow();

            if (Properties.Settings.Default.English == true)
            {

                HeaderEnglishSetting.IsChecked = true;
                HeaderFrenchSetting.IsChecked = false;
                HeaderSpanishSetting.IsChecked = false;
                newfile = "Create new project";
                openfile = "Open project";
                FileMenu.Header = "File";
                NewFileMenu.Header = "New";
                OpenFileMenu.Header = "Open";
                EditMenu.Header = "Edit";
                DeleteWordMenu.Header = "Delete word";
                DeleteWordMenu.InputGestureText = "CTRL + Delete";
                ChangeWordMenu.Header = "Change word";
                ExportMenu.Header = "Export";
                ExportXMLMenu.Header = "Export as XML file";
                ExportJSONMenu.Header = "Export as JSON file";
                ExportRTFMenu.Header = "Export as RTF file";
                SortXMLMenu.Header = "Sort XML";
                SortXMLwordMenu.Header = "Sort by word";
                SortXMLtranslationMenu.Header = "Sort by translation";
                SortXMLPOSMenu.Header = "Sort by POS";
                SortXMLglossMenu.Header = "Sort by gloss";
                OptionsMenu.Header = "Options";
                SettingsMenu.Header = "Settings";
                LanguageMenu.Header = "Language";
                HelpMenu.Header = "Help";
                TextBlockWord.Text = "Word";
                TextBlockTranslation.Text = "Translation";
                TextBlockPronunciation.Text = "IPA";
                TextBlockDefinition.Text = "Definition";
                TextBlockExample.Text = "Example";
                TextBlockPOS.Text = "POS";
                TextBlockGloss.Text = "Gloss";
                btnAddWord.Content = "Add word";
                dgWords.Columns[0].Header = "Word";
                dgWords.Columns[1].Header = "Translation";
                dgWords.Columns[2].Header = "Pronunciation";
                dgWords.Columns[3].Header = "Definition";
                dgWords.Columns[4].Header = "Example";
                dgWords.Columns[5].Header = "POS";
                dgWords.Columns[6].Header = "Gloss";
                ComboBoxPOS.ItemsSource = Enum.GetValues(typeof(EnumPOSClass.AllPOS)).Cast<EnumPOSClass.AllPOS>();
                ChangeWordButton.Content = "Change word";
                RemoveWordButton.Content = "Delete word";
                TextBlockSearchWord.Text = "Search";
            }
        }

    }
    public partial class ChangeWordWindow : Window
    {
        private void LoadChangeWordLoadEnglishSetting()
        {
            if (Properties.Settings.Default.French == true)
            {
                TextBlockWordChange.Text = "Change word:";
                TextBlockTranslationChange.Text = "Change translation:";
                TextBlockDefinitionChange.Text = "Change definition:";
                TextBlockExampleChange.Text = "Change example:";
                TextBlockPOSChange.Text = "Change POS:";
                TextBlockGlossChange.Text = "Change gloss:";
                btnChangeDone.Content = "OK";
                btnChangeCancel.Content = "Cancel";
            }
        }
    }
}
