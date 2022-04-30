using System;
using System.Windows;

namespace Dictionary_Maker
{

    public partial class ChangeWordWindow : Window
    {

        public ChangeWordWindow()
        {    
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            InitializeComponent();
            ChangeWordLoadLanguageSettings();
        }

        public string ChangecbPOS()
        {
            string ChangecbPOSText = ChangeComboBoxPOS.Text.ToString();
            return ChangecbPOSText;
        }
        public string ChangecbGloss()
        {
            string ChangecbGlossText = ChangeComboBoxGloss.Text.ToString();
            return ChangecbGlossText;
        }


        public void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

    }
}
