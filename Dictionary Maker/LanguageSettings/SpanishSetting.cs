using System;
using System.Linq;
using System.Windows;


namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {

        public void Spanishunchecked(object sender, RoutedEventArgs e)
        {
            spanishsetting = false;
            Properties.Settings.Default.Spanish = englishsetting;
            Properties.Settings.Default.Save();
            LoadSpanishSetting();
        }

        public void Spanishchecked(object sender, RoutedEventArgs e)
        {
            englishsetting = false;
            frenchsetting = false;
            spanishsetting = true;
            Properties.Settings.Default.Spanish = spanishsetting;
            Properties.Settings.Default.Save();
            LoadSpanishSetting();
        }

        public void LoadSpanishSetting()
        {


            if (Properties.Settings.Default.Spanish == true)
            {
                HeaderEnglishSetting.IsChecked = false;
                HeaderFrenchSetting.IsChecked = false;
                HeaderSpanishSetting.IsChecked = true;
                newfile = "Crear nuevo proyecto";
                openfile = "Abrir proyecto";
                FileMenu.Header = "Archivo";
                NewFileMenu.Header = "Nuevo";
                OpenFileMenu.Header = "Abrir";
                EditMenu.Header = "Editar";
                DeleteWordMenu.Header = "Borrar palabra";
                DeleteWordMenu.InputGestureText = "CTRL + Supr";
                ChangeWordMenu.Header = "Cambrar palabra";
                ExportMenu.Header = "Exportar";
                ExportXMLMenu.Header = "Exportar como XML";
                ExportJSONMenu.Header = "Exportar como JSON";
                ExportRTFMenu.Header = "Exportar como RTF";
                SortXMLMenu.Header = "Ordenar XML";
                SortXMLwordMenu.Header = "Ordenar por palabra";
                SortXMLtranslationMenu.Header = "Ordenar por traductíon";
                SortXMLPOSMenu.Header = "Ordenar por PDO";
                SortXMLglossMenu.Header = "Ordenar por glosa";
                OptionsMenu.Header = "Opciones";
                SettingsMenu.Header = "Configuracíon";
                LanguageMenu.Header = "Idioma";
                HelpMenu.Header = "Ayuda";
                TextBlockWord.Text = "Palabra";
                TextBlockTranslation.Text = "Traduccíon";
                TextBlockPronunciation.Text = "AFI";
                TextBlockDefinition.Text = "Deffinicíon";
                TextBlockExample.Text = "Ejemplo";
                TextBlockPOS.Text = "PDO";
                TextBlockGloss.Text = "Glosa";
                btnAddWord.Content = "Agregar palabra";
                dgWords.Columns[0].Header = "Palabra";
                dgWords.Columns[1].Header = "Traduccíon";
                dgWords.Columns[2].Header = "Pronunciacíon";
                dgWords.Columns[3].Header = "Definición";
                dgWords.Columns[4].Header = "Ejemplo";
                dgWords.Columns[5].Header = "PDO";
                dgWords.Columns[6].Header = "Glosa";
                ComboBoxPOS.ItemsSource = Enum.GetValues(typeof(EnumPOSClass.AllPOSSpanish)).Cast<EnumPOSClass.AllPOSSpanish>();
                ChangeWordButton.Content = "Cambiar palabra";
                RemoveWordButton.Content = "Borrar palabra";
                TextBlockSearchWord.Text = "Buscar";
            }
        }

    }
    public partial class ChangeWordWindow : Window
    {
        private void LoadChangeWordLoadSpanishSetting()
        {
            if (Properties.Settings.Default.Spanish == true)
            {
                TextBlockWordChange.Text = "Cambiar palabra:";
                TextBlockTranslationChange.Text = "Cambiar traduccíon:";
                TextBlockDefinitionChange.Text = "Cambiar definitíon:";
                TextBlockExampleChange.Text = "Cambiar ejemplo:";
                TextBlockPOSChange.Text = "Cambiar PDO:";
                TextBlockGlossChange.Text = "Cambiar glosa:";
                btnChangeDone.Content = "OK";
                btnChangeCancel.Content = "Anular";
                Title = "Cambiar palabra";
            }
        }
    }
}
