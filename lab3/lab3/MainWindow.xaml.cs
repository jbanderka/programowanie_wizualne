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

namespace lab3
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
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == true)
                File.WriteAllText(saveDialog.FileName, csvData.ToString());
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if(openDialog.ShowDialog() == true)
            {
                listV.ItemsSource = new List<Row>();
                foreach (string fileLine in File.ReadLines(openDialog.FileName))
                {
                    string[] fields = fileLine.Split(',');
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
