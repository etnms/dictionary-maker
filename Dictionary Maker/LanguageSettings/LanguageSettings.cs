using System.Windows;

namespace Dictionary_Maker
{
   public partial class MainWindow : Window
    {
        public string openfile;
        public string newfile;
        public bool frenchsetting = false;
        public bool englishsetting = false;
        public bool spanishsetting = false;
        public void LoadLanguageSettings()
        {
            if (Properties.Settings.Default.English == true )
            {
                LoadEnglishSetting();
            }
            if (Properties.Settings.Default.French == true )
            {
                LoadFrenchSetting();
            }
            if (Properties.Settings.Default.Spanish == true)
            {
                LoadSpanishSetting();
            }
        }
    }
}
