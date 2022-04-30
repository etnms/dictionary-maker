using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Export xml file content into an rtf file, while also giving a preview
/// </summary>
namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {

        private void btnRTFexport_click(object sender, RoutedEventArgs e)
        {
            //choosing location to save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RTF files (*.rtf)|*.rtf";

            //Alphabetical sorting of the words // use of the method sort xml by word 
            SortXmlByWordNoClick();

             //Prepare writing in rtf document
             XmlDocument doc = new XmlDocument();
            doc.Load(userfile);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("WordInDictionary");

            // Open preview window
            RtfWindow rtfWindow = new RtfWindow();

            //Clear the preview doc before loading
            rtfWindow.rtfeditor.Document.Blocks.Clear();

            var bc = new BrushConverter(); // choose color for translation

            //write every element in the file
            foreach (XmlNode node in nodes)
            {
              
                Paragraph para = new Paragraph();

                para.Inlines.Add(new Run("      "));
                para.Inlines.Add(new Bold(new Run(node["Word"].InnerText)));
                para.Inlines.Add(new Run(" ("));
                para.Inlines.Add(new Run(node["POS"].InnerText));
                if (node["Gloss"].InnerText == "")
                {
                    para.Inlines.Add(new Run(") "));
                }
                if (node["Gloss"].InnerText != "")
                {
                    para.Inlines.Add(new Run(", " + node["Gloss"].InnerText + ") "));
                }

                para.Inlines.Add(new Run(node["Translation"].InnerText)
                {
                    Foreground = (Brush)bc.ConvertFrom("#6A6E9B")
                });
                para.Inlines.Add(new Run(". " + node["Definition"].InnerText));

                para.Inlines.Add(new LineBreak());

                para.Inlines.Add(new Italic(new Run(node["Example"].InnerText)));

                rtfWindow.rtfeditor.Document.Blocks.Add(para);
            }

            //Save rtf file
            TextRange range;
            FileStream fStream;
            range = new TextRange(rtfWindow.rtfeditor.Document.ContentStart, rtfWindow.rtfeditor.Document.ContentEnd);
            if (saveFileDialog.ShowDialog() == true)
            {
                // create file if file doesn't already exist and is not used 
                try
                {
                    fStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    range.Save(fStream, DataFormats.Rtf);
                    fStream.Close();
                    rtfWindow.ShowDialog();
                }
                catch // error message if the file is already opened in a different application
                {
                    ErrorWindow errorWindow = new ErrorWindow();
                    errorWindow.Title = "Error";
                    errorWindow.ErrorMessage.Text = "This file is already opened in a different application. \nPlease close it and try again.";
                    errorWindow.ShowDialog();
                }
            }

        }
    }
}