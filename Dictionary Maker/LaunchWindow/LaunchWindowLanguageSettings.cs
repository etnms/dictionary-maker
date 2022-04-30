using System.Windows;
using System.Windows.Controls;

namespace Dictionary_Maker
{
    public partial class LaunchWindow : Window
    {
        public string newprojectdialog;
        public string openprojectdialog;     
        public void LaunchWindowLanguageChange(object sender, SelectionChangedEventArgs args)
        {
            if (CBLanguage.SelectedIndex == 0)
            {
                Properties.Settings.Default.English = true;
                Properties.Settings.Default.French = false;
                Properties.Settings.Default.Spanish = false;
                LaunchNewProject.Content = "New project";
                LaunchOpenProject.Content = "Open project";
                newprojectdialog = "Create new project";
                openprojectdialog = "Open project";
                LaunchEnglish.IsSelected = true;
                Properties.Settings.Default.Save();              
            }

            if (CBLanguage.SelectedIndex == 1)
            {
                Properties.Settings.Default.English = false;
                Properties.Settings.Default.French = false;
                Properties.Settings.Default.Spanish = true;
                LaunchNewProject.Content = "Nuevo proyecto";               
                LaunchOpenProject.Content = "Abrir proyecto";
                newprojectdialog = "Crear nuevo proyecto";
                openprojectdialog = "Abrir proyecto";
                LaunchSpanish.IsSelected = true;
                CBLanguage.Text = "Elige un idioma";
                Properties.Settings.Default.Save();
            }

            if (CBLanguage.SelectedIndex == 2)
            {
                Properties.Settings.Default.English = false;
                Properties.Settings.Default.French = true;
                Properties.Settings.Default.Spanish = false;
                LaunchNewProject.Content = "Nouveau projet";
                LaunchOpenProject.Content = "Ouvrir projet";
                newprojectdialog = "Créer nouveau projet";
                openprojectdialog = "Ouvrir projet";
                LaunchFrench.IsSelected = true;
                CBLanguage.Text = "Choix de la langue";
                Properties.Settings.Default.Save();
            }
            ComboBoxLanguage();
        }

        private void ComboBoxLanguage()
        {
            if (Properties.Settings.Default.English == true)
            {
                LaunchEnglish.IsSelected = true;
            }
            if (Properties.Settings.Default.French == true)
            {
                LaunchFrench.IsSelected = true;
            }
            if (Properties.Settings.Default.Spanish == true)
            {
                LaunchSpanish.IsSelected = true;
            }
        }
    }
}
