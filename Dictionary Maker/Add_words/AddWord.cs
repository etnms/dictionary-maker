using System;
using System.Windows;
using System.Xml;

/// <summary>
/// Method to add words to the dictionnary
/// </summary>

namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {

        public void AddWord(object sender, RoutedEventArgs e)
        {       
            string cbPOSText = ComboBoxPOS.Text.ToString();
            string cbGlossText = ComboBoxGloss.Text.ToString();

            //Error window if empty space
            if (txtWord.Text == "") // Making sure empty spaces can't be added
            {
                LoadErrorWindowEmptySelection();
            }
            else
            {
                //New document
                XmlDocument doc = new XmlDocument();
                //Opening XML file
                doc.Load(userfile);

                var drawingNodes = doc.SelectNodes("//Word");


                //Description of each word
                XmlElement widxml = doc.CreateElement("WordInDictionary");
                doc.DocumentElement.AppendChild(widxml);

                //Adding new nodes for each element
                XmlNode wordxml = doc.CreateElement(string.Empty, "word", string.Empty);
                wordxml.InnerText = txtWord.Text.ToLower();
                widxml.AppendChild(wordxml);

                XmlNode transxml = doc.CreateElement(string.Empty, "translation", string.Empty);
                transxml.InnerText = txtTranslation.Text.ToLower();
                widxml.AppendChild(transxml);

                XmlNode defxml = doc.CreateElement(string.Empty, "definition", string.Empty);
                defxml.InnerText = txtDefinition.Text;
                widxml.AppendChild(defxml);

                XmlNode examplexml = doc.CreateElement(string.Empty, "example", string.Empty);
                examplexml.InnerText = txtExample.Text;
                widxml.AppendChild(examplexml);

                XmlNode posxml = doc.CreateElement(string.Empty, "pos", string.Empty);
                posxml.InnerText = cbPOSText;
                widxml.AppendChild(posxml);

                XmlNode glossxml = doc.CreateElement(string.Empty, "gloss", string.Empty);
                glossxml.InnerText = cbGlossText;
                widxml.AppendChild(glossxml);

                //Saving changes
                doc.Save(userfile);

                //Add items to the collection
                items.Add(new WordInDictionary()
                {
                    Word = wordxml.InnerText.ToLower(),
                    Translation = txtTranslation.Text.ToLower(),
                    Definition = txtDefinition.Text,
                    Example = txtExample.Text,
                    POS = cbPOSText,
                    Gloss = cbGlossText,
                });
                ClearBoxes();
            }
        }

        // Empty the boxes
        public void ClearBoxes()
        {
            txtWord.Text = string.Empty;
            txtTranslation.Text = string.Empty;
            txtDefinition.Text = string.Empty;
            txtExample.Text = string.Empty;
            ComboBoxPOS.SelectedIndex = -1;
            ComboBoxGloss.SelectedIndex = -1;

        }

    }
}
