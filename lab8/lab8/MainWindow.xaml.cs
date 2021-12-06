using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // string allFileContent;
            int NumOfAirportFiles = 7;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

            }
        }

        private void seeDetails_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Airport
    {
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string Name { get; set; }
        public int Passengers { get; set; }
        public int Change { get; set; }
    }
}
