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
using System.Windows.Shapes;

namespace lab3
{
    /// <summary>
    /// Interaction logic for WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        MainWindow mainWindow;
        public WindowAdd(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void addRow_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.id += 1;
            List<Row> items = (List<Row>)mainWindow.listV.ItemsSource;
            items.Add(new Row() { Name = addName.Text, Id = mainWindow.id, Count = int.Parse(addCount.Text) });
            mainWindow.listV.ItemsSource = items;
            mainWindow.listV.Items.Refresh();
            this.Close();
        }
    }
}
