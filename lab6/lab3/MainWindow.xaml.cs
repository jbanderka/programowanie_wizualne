using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Xml.Serialization;

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int id = 0;
        public MainWindow()
        {
            InitializeComponent();
            listV.ItemsSource = new List<Row>();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowAdd = new WindowAdd(this);
            windowAdd.Show();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder csvData = new StringBuilder();
            foreach(Row listRow in listV.ItemsSource)
            {
                string line = string.Format($"{listRow.Name},{listRow.Id},{listRow.Count}");
                csvData.AppendLine(line);
            }
            string data = csvData.ToString();
            XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*";
            if (saveDialog.ShowDialog() == true)
            {
                TextWriter writer = new StreamWriter(saveDialog.FileName);
                xmlSerializer.Serialize(writer, data);
                writer.Close();
                //File.WriteAllText(saveDialog.FileName, csvData.ToString());
            }
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if(openDialog.ShowDialog() == true)
            {
                listV.ItemsSource = new List<Row>();
                string fileData;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(string));
                StreamReader reader = new StreamReader(openDialog.FileName);
                fileData = (string)xmlSerializer.Deserialize(reader);
                char[] delims = new[] { '\r', '\n' };
                string[] entries = fileData.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                id = 0;
                foreach(string entry in entries)
                {
                    string[] fields = entry.Split(',');
                    id += 1;
                    List<Row> items = (List<Row>)listV.ItemsSource;
                    items.Add(new Row() { Name = fields[0], Id = int.Parse(fields[1]), Count = int.Parse(fields[2]) });
                    listV.ItemsSource = items;
                    listV.Items.Refresh();
                }
                id = listV.Items.Count;
            }
        }
    }

    public class Row
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
