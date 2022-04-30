using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Linq;

namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {
        private void SortByWord_Click(object sender, RoutedEventArgs e)
        {
            var xDoc = XDocument.Load(userfile);

            XDocument output = new XDocument(new XElement("ArrayOfWordInDictionary",
                xDoc.Root
                .Elements("WordInDictionary")
                .OrderBy(node => node.Element("Word").Value)));

            output.Save(userfile);

            items.Clear();
            LoadList();

        }

        public void SortXmlByWordNoClick() // same as SortByWord_Click but can be used outside the button context
        {
            var xDoc = XDocument.Load(userfile);

            XDocument output = new XDocument(new XElement("ArrayOfWordInDictionary",
                xDoc.Root
                .Elements("WordInDictionary")
                .OrderBy(node => node.Element("Word").Value)));

            output.Save(userfile);

            items.Clear();
            LoadList();
        }
        private void SortByTranslation_Click(object sender, RoutedEventArgs e)
        {
            var xDoc = XDocument.Load(userfile);

            XDocument output = new XDocument(new XElement("ArrayOfWordInDictionary",
                xDoc.Root
                .Elements("WordInDictionary")
                .OrderBy(node => node.Element("Translation").Value)));

            output.Save(userfile);

            items.Clear();
            LoadList();

        }

        private void SortByPOS_Click(object sender, RoutedEventArgs e)
        {
            var xDoc = XDocument.Load(userfile);

            XDocument output = new XDocument(new XElement("ArrayOfWordInDictionary",
                xDoc.Root
                .Elements("WordInDictionary")
                .OrderBy(node => node.Element("POS").Value)));

            output.Save(userfile);

            items.Clear();
            LoadList();

        }

        private void SortByGloss_Click(object sender, RoutedEventArgs e)
        {
            var xDoc = XDocument.Load(userfile);

            XDocument output = new XDocument(new XElement("ArrayOfWordInDictionary",
                xDoc.Root
                .Elements("WordInDictionary")
                .OrderBy(node => node.Element("Gloss").Value)));

            output.Save(userfile);

            items.Clear();
            LoadList();

        }

        // organize alphabetically
        //for words
        private void dgWordsSorting_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                dgWords.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            dgWords.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

    }


    public class SortAdorner : Adorner
    {
        private static Geometry ascGeometry =
            Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

        private static Geometry descGeometry =
            Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement element, ListSortDirection dir)
            : base(element)
        {
            this.Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            TranslateTransform transform = new TranslateTransform
                (
                    AdornedElement.RenderSize.Width - 15,
                    (AdornedElement.RenderSize.Height - 5) / 2
                );
            drawingContext.PushTransform(transform);

            Geometry geometry = ascGeometry;
            if (this.Direction == ListSortDirection.Descending)
                geometry = descGeometry;
            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }


    }
}
