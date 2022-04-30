using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Xml.Serialization;

namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {
        private void btnJSONexport_click(object sender, RoutedEventArgs e)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(items, options);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, jsonString);

        }

        private void btnXMLexport_click(object sender, RoutedEventArgs e)
        {

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<WordInDictionary>));
            using (StreamWriter wr = new StreamWriter(userfile))

            {
                xs.Serialize(wr, items);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
                using (StreamWriter wr = new StreamWriter(saveFileDialog.FileName))

                {
                    xs.Serialize(wr, items);
                }
        }
    }
}