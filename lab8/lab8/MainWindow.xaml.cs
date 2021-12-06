using Microsoft.VisualBasic.FileIO;
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
        public List<Airport> allAirports;
        public MainWindow()
        {
            InitializeComponent();
            airportsList.ItemsSource = new List<string>();
            allAirports = new List<Airport>();

            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                using (TextFieldParser csvParser = new TextFieldParser(openFile.FileName))
                {
                    csvParser.CommentTokens = new string[] { "#" };
                    csvParser.SetDelimiters(new string[] { "," });
                    csvParser.HasFieldsEnclosedInQuotes = true;

                    bool skipFirst = true;

                    while (!csvParser.EndOfData)
                    {
                        string[] fields = csvParser.ReadFields();
                        if(skipFirst)
                        {
                            skipFirst = false;
                        }
                        else
                        {
                            List<string> allAirportsNames = (List<string>)airportsList.ItemsSource;
                            allAirportsNames.Add(fields[4]);
                            airportsList.ItemsSource = allAirportsNames;
                            airportsList.Items.Refresh();
                            allAirports.Add(new Airport
                            {
                                City = fields[0],
                                Voivodeship = fields[1],
                                ICAO = fields[2],
                                IATA = fields[3],
                                Name = fields[4],
                                Passengers = fields[5],
                                Change = fields[6]
                            });
                        }
                    }
                }
            }
        }

        private void seeDetails_Click(object sender, RoutedEventArgs e)
        {
            if (airportsList.SelectedIndex < 0)
            {
                MessageBox.Show("W celu wyświetlenia szczegółów należy wybrać lotnisko!",
                    "Błąd wyświetlenia szczegółów", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DetailsWindow detailsWindow = new DetailsWindow(this);
                detailsWindow.Show();
                airportsList.SelectedIndex = -1;
                icaoCode.IsChecked = false;
                iataCode.IsChecked = false;
                passengersNumber.IsChecked = false;
                voivodeship.IsChecked = false;
                city.IsChecked = false;
            }
        }
    }

    public class Airport
    {
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string Name { get; set; }
        public string Passengers { get; set; }
        public string Change { get; set; }
    }
}
