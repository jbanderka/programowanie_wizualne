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

    }

    public class Row
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
