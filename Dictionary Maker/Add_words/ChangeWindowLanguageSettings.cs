using System.Windows;

namespace Dictionary_Maker
{
    public partial class ChangeWordWindow : Window
    {
        public void ChangeWordLoadLanguageSettings()
        {
            if (Properties.Settings.Default.English == true)
            {
                LoadChangeWordLoadEnglishSetting();
            }
            if (Properties.Settings.Default.French == true)
            {
                LoadChangeWordLoadFrenchSetting();
            }
            if (Properties.Settings.Default.Spanish == true)
            {
                LoadChangeWordLoadSpanishSetting();
            }

        }
    }
}
