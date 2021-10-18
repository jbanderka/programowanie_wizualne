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

namespace lab2
{
    /// <summary>
    /// Interaction logic for BrandWindow.xaml
    /// </summary>
    public partial class BrandWindow : Window
    {
        double additionPrice = 0;
        double basePrice = 0;
        public BrandWindow(object sender)
        {
            InitializeComponent();

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ford_Checked(object sender, RoutedEventArgs e)
        {
            basePrice = 50000;
            price.Content = basePrice + "€";
        }

        private void fiat_Checked(object sender, RoutedEventArgs e)
        {
            basePrice = 30000;
            price.Content = basePrice + "€";
        }

        private void ferrari_Checked(object sender, RoutedEventArgs e)
        {
            basePrice = 120000;
            price.Content = basePrice + "€";
        }
    }
}
