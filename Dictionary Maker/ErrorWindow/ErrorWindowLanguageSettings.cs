using System.Windows;

namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {
       
        public void LoadErrorWindowSelection()
        { 
            ErrorWindow ErrorWindow = new ErrorWindow();

            if (Properties.Settings.Default.English == true)
            {
                ErrorWindow.Title = "Error: empty selection";
                ErrorWindow.ErrorMessage.Text = "Error: You need to select a word first.";
                ErrorWindow.ShowDialog();
            }

            if (Properties.Settings.Default.French == true)
            {
                ErrorWindow.Title = "Erreur: sélection vide";
                ErrorWindow.ErrorMessage.Text = "Erreur: Vous devez d'abord sélectionner un mot.";
                ErrorWindow.ShowDialog();
            }

            if (Properties.Settings.Default.Spanish == true)
            {
                ErrorWindow.Title = "Error: selección vacía ";
                ErrorWindow.ErrorMessage.Text = "Error: Necesita seleccionar un palabra.";
                ErrorWindow.ShowDialog();
            }
        }

        public void LoadErrorWindowEmptySelection()
        {
            ErrorWindow ErrorWindow = new ErrorWindow();
            if (Properties.Settings.Default.English == true)
            {
                ErrorWindow.Title = "Error: Empty space";
                ErrorWindow.ErrorMessage.Text = "Error: You can't add an empty space.";
                ErrorWindow.ShowDialog();
            }

            if (Properties.Settings.Default.French == true)
            {
                ErrorWindow.Title = "Erreur: espace vide";
                ErrorWindow.ErrorMessage.Text = "Erreur: Vous ne pouvez pas ajouter d'espace vide.";
                ErrorWindow.ShowDialog();
            }

            if (Properties.Settings.Default.Spanish == true)
            {
                ErrorWindow.Title = "Error: espacio vacía ";
                ErrorWindow.ErrorMessage.Text = "Error: No puede agregar un espacio vacío.";
                ErrorWindow.ShowDialog();
            }
        }
    }
}
