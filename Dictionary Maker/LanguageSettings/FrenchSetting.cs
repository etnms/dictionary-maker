using System;
using System.Linq;
using System.Windows;

namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {

        private void Frenchunchecked(object sender, RoutedEventArgs e)
        {            
            Properties.Settings.Default.French = frenchsetting;
            Properties.Settings.Default.Save();
            LoadFrenchSetting();
        }

        private void Frenchchecked(object sender, RoutedEventArgs e)
        {
            frenchsetting = true;
            englishsetting = false;
            spanishsetting = false;
            Properties.Settings.Default.French = frenchsetting;
            Properties.Settings.Default.Save();
            LoadFrenchSetting();
        }

        public void LoadFrenchSetting()
        {
            
            if (Properties.Settings.Default.French == true)
            {
                HeaderEnglishSetting.IsChecked = false;
                HeaderFrenchSetting.IsChecked = true;
                HeaderSpanishSetting.IsChecked = false;
                newfile = "Créer nouveau projet";
                openfile = "Ouvrir projet";
                FileMenu.Header = "Fichier";
                NewFileMenu.Header = "Nouveau";
                OpenFileMenu.Header = "Ouvrir";
                EditMenu.Header = "Editer";
                DeleteWordMenu.Header = "Supprimer mot";
                DeleteWordMenu.InputGestureText = " CTRL + Suppr";
                ChangeWordMenu.Header = "Modifier mot";
                ExportMenu.Header = "Exporter";
                ExportXMLMenu.Header = "Exporter au format XML";
                ExportJSONMenu.Header = "Exporter au format JSON";
                SortXMLMenu.Header = "Trier XML";
                SortXMLwordMenu.Header = "Trier par mot";
                SortXMLtranslationMenu.Header = "Trier par traduction";
                SortXMLPOSMenu.Header = "Trier par POS";
                SortXMLglossMenu.Header = "Trier par glose";
                OptionsMenu.Header = "Options";
                SettingsMenu.Header = "Paramètres";
                LanguageMenu.Header = "Langue";
                HelpMenu.Header = "Aide";
                TextBlockWord.Text = "Mot";
                TextBlockTranslation.Text = "Traduction";
                TextBlockPronunciation.Text = "API";
                TextBlockDefinition.Text = "Definition";
                TextBlockExample.Text = "Exemple";
                TextBlockPOS.Text = "POS";
                TextBlockGloss.Text = "Glose";
                btnAddWord.Content = "Ajouter mot";
                dgWords.Columns[0].Header = "Mot";
                dgWords.Columns[1].Header = "Traduction";
                dgWords.Columns[2].Header = "Prononciation";
                dgWords.Columns[3].Header = "Définition";
                dgWords.Columns[4].Header = "Exemple";
                dgWords.Columns[5].Header = "POS";
                dgWords.Columns[6].Header = "Glose";
                ComboBoxPOS.ItemsSource = Enum.GetValues(typeof(EnumPOSClass.AllPOSFrench)).Cast<EnumPOSClass.AllPOSFrench>();
                ChangeWordButton.Content = "Changer mot";
                RemoveWordButton.Content = "Supprimer mot";
                TextBlockSearchWord.Text = "Chercher";      
            }
        }
    }

    public partial class ChangeWordWindow : Window
    {
        private void LoadChangeWordLoadFrenchSetting()
        {
            if (Properties.Settings.Default.French == true)
            {
                TextBlockWordChange.Text = "Changer mot:";
                TextBlockTranslationChange.Text = "Changer traduction:";
                TextBlockDefinitionChange.Text = "Changer définition:";
                TextBlockExampleChange.Text = "Changer exemple:";
                TextBlockPOSChange.Text = "Changer POS:";
                TextBlockGlossChange.Text = "Changer glose:";
                btnChangeDone.Content = "OK";
                btnChangeCancel.Content = "Annuler";
                Title = "Changer mot";
            }
        }
    }

}
