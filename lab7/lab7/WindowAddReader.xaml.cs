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

namespace lab7
{
    /// <summary>
    /// Interaction logic for WindowAddReader.xaml
    /// </summary>
    public partial class WindowAddReader : Window
    {
        MainWindow mainWindow;
        public WindowAddReader(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.idReader += 1;
            List<Reader> readersList = (List<Reader>)mainWindow.readers.ItemsSource;
            readersList.Add(new Reader() { Name = addName.Text, Surname = addSurname.Text, Id = mainWindow.idReader });
            mainWindow.readers.ItemsSource = readersList;
            mainWindow.readers.Items.Refresh();
            this.Close();
        }
    }
}
