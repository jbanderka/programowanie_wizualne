using System;
using System.Configuration;
using System.Collections.Specialized;
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
using System.Text.RegularExpressions;
using System.Reflection;

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int id = 0;
        public List<Row> allItems;
        public MainWindow()
        {
            InitializeComponent();
            listV.ItemsSource = new List<Row>();
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;
            string lastPath = sAll.Get("LastPath");
            if(lastPath != "")
            {
                listV.ItemsSource = new List<Row>();
                string fileData;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(string));
                StreamReader reader = new StreamReader(lastPath);
                fileData = (string)xmlSerializer.Deserialize(reader);
                char[] delims = new[] { '\r', '\n' };
                string[] entries = fileData.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                id = 0;
                foreach (string entry in entries)
                {
                    string[] fields = entry.Split(',');
                    id += 1;
                    List<Row> items = (List<Row>)listV.ItemsSource;
                    items.Add(new Row() { Name = fields[0], Id = int.Parse(fields[1]), Count = int.Parse(fields[2]) });
                    listV.ItemsSource = items;
                    listV.Items.Refresh();
                }
                if (allItems != null)
                    allItems.Clear();
                allItems = (List<Row>)listV.ItemsSource;
                id = listV.Items.Count;
            }
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowAdd = new WindowAdd(this);
            windowAdd.Show();
            allItems = (List<Row>)listV.ItemsSource;
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
            if(saveDialog.ShowDialog() == true)
            {
                TextWriter writer = new StreamWriter(saveDialog.FileName);
                xmlSerializer.Serialize(writer, data);
                writer.Close();
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
                if(allItems != null)
                    allItems.Clear();
                allItems = (List<Row>)listV.ItemsSource;
                id = listV.Items.Count;

                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                configuration.AppSettings.Settings["LastPath"].Value = openDialog.FileName;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać zawartość?",
                "Zapis", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                save.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string searchText = toSearch.Text;
            if (Regex.IsMatch(searchText, @"^[0-9]+$"))
            {
                // searchText is numeric
                int searchNumber = int.Parse(searchText);
                List<Row> filteredItems = new List<Row>();
                foreach (Row listRow in listV.ItemsSource)
                {
                    if (listRow.Count == searchNumber)
                        filteredItems.Add(listRow);
                }
                listV.ItemsSource = filteredItems;
            }
            else if (Regex.IsMatch(searchText, @"^[a-zA-Z]+$"))
            {
                // searchText contains only letters
                List<Row> filteredItems = new List<Row>();
                foreach (Row listRow in listV.ItemsSource)
                {
                    if (listRow.Name == searchText)
                        filteredItems.Add(listRow);
                }
                listV.ItemsSource = filteredItems;
            }
            else if(searchText != "")
            {
                // searchText contains numbers, letters (and maybe special characters)
                MessageBox.Show("Tekst do wyszukiwania musi zawierać tylko litery lub tylko cyfry!", "Błąd wyszukiwania",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void clearSearch_Click(object sender, RoutedEventArgs e)
        {
            toSearch.Text = "";
            listV.ItemsSource = allItems;
        }
    }

    public class Row
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
