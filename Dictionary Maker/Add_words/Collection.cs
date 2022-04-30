using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;



/// <summary>
/// Load item collection when file is open + Collection class 
/// </summary>
/// 

namespace Dictionary_Maker
{

    public partial class MainWindow : Window
    {

        public ObservableCollection<WordInDictionary> items = new ObservableCollection<WordInDictionary>();

        public void LoadList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userfile);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("WordInDictionary");
            foreach (XmlNode node in nodes)
            {
                items.Add(new WordInDictionary()
                {
                    Word = node["Word"].InnerText,
                    Translation = node["Translation"].InnerText,
                    Definition = node["Definition"].InnerText,
                    Example = node["Example"].InnerText,
                    POS = node["POS"].InnerText,
                    Gloss = node["Gloss"].InnerText,

                });
            }
            dgWords.ItemsSource = items;
        }
    }

    public class WordInDictionary : INotifyPropertyChanged

    {

        [XmlElement(ElementName = "Word")]

        private string word;
        public string Word
        {
            get { return this.word; }
            set
            {
                if (this.word != value)
                {
                    this.word = value;
                    this.NotifyPropertyChanged("Word");
                }
            }
        }

        [XmlElement("Translation")]
        private string translation;
        public string Translation
        {
            get { return this.translation; }
            set
            {
                if (this.translation != value)
                {
                    this.translation = value;
                    this.NotifyPropertyChanged("Translation");
                }
            }
        }

        [XmlElement("Definition")]
        private string definition;
        public string Definition
        {
            get { return this.definition; }
            set
            {
                if (this.definition != value)
                {
                    this.definition = value;
                    this.NotifyPropertyChanged("Definition");
                }
            }
        }

        [XmlElement("Example")]
        private string example;
        public string Example
        {
            get { return this.example; }
            set
            {
                if (this.example != value)
                {
                    this.example = value;
                    this.NotifyPropertyChanged("Example");
                }
            }
        }

        [XmlElement("POS")]
        private string pos;
        public string POS
        {
            get { return this.pos; }
            set
            {
                if (this.pos != value)
                {
                    this.pos = value;
                    this.NotifyPropertyChanged("POS");
                }
            }
        }

        [XmlElement("Gloss")]
        private string gloss;
        public string Gloss
        {
            get { return this.gloss; }
            set
            {
                if (this.gloss != value)
                {
                    this.gloss = value;
                    this.NotifyPropertyChanged("Gloss");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }

}





