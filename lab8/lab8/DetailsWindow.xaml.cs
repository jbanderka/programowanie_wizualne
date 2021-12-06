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

namespace lab8
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        MainWindow mainWin;
        public DetailsWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            mainWin = mainWindow;
            int selectedInd = mainWin.airportsList.SelectedIndex;
            Airport selectedAirport = mainWin.allAirports[selectedInd];
            string textToDisplay = "";
            if (mainWin.icaoCode.IsChecked == true)
            {
                textToDisplay += "Kod ICAO: " + selectedAirport.ICAO + "\n";
            }
            if (mainWin.iataCode.IsChecked == true)
            {
                textToDisplay += "Kod IATA: " + selectedAirport.IATA + "\n";
            }
            if (mainWin.passengersNumber.IsChecked == true)
            {
                textToDisplay += "Liczba pasażerów: " + selectedAirport.Passengers + "\n";
            }
            if (mainWin.voivodeship.IsChecked == true)
            {
                textToDisplay += "Województwo: " + selectedAirport.Voivodeship + "\n";
            }
            if (mainWin.city.IsChecked == true)
            {
                textToDisplay += "Miasto: " + selectedAirport.City + "\n";
            }

            if(textToDisplay == "")
                textToDisplay = "Nie wybrano, żadnego pola do wyświetlenia.";

            details.Text = textToDisplay;
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            /*mainWin.airportsList.SelectedIndex = -1;
            mainWin.icaoCode.IsChecked = false;
            mainWin.iataCode.IsChecked = false;
            mainWin.passengersNumber.IsChecked = false;
            mainWin.voivodeship.IsChecked = false;
            mainWin.city.IsChecked = false;*/
            this.Close();
        }
    }
}
