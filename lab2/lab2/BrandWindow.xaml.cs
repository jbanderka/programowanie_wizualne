<<<<<<< HEAD
﻿using System;
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
        double basePrice = 0; 
        double additionalPrice = 0;
        double insurance = 0;
        MainWindow mainW;
        
        public BrandWindow(MainWindow window)
        {
            InitializeComponent();
            mainW = window;
            FinalPrice.brandPrice = 0;
            price.Content = FinalPrice.enginePrice + "€";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FinalPrice.brandPrice = basePrice + additionalPrice + insurance;
            mainW.price.Content = FinalPrice.brandPrice + FinalPrice.enginePrice + "€";
            this.Close();
        }

        private void fiat_Checked(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            basePrice = 30000;
            price.Content = FinalPrice.enginePrice + basePrice + "€";
        }

        private void ford_Checked(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            basePrice = 50000;
            price.Content = FinalPrice.enginePrice + basePrice + "€";
        }

        private void ferrari_Checked(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            basePrice = 120000;
            price.Content = FinalPrice.enginePrice + basePrice + "€";
        }

        private void steeringWheel_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 100;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void steeringWheel_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 100;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void seats_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 300;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void seats_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 300;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void drive_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 1000;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void drive_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 1000;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void sunroof_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 800;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void sunroof_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 800;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void UncheckAll()
        {
            steeringWheel.IsChecked = false;
            seats.IsChecked = false;
            drive.IsChecked = false;
            sunroof.IsChecked = false;
            insurance = 0;
            insurancePolicy.Text = "0";
        }

        private void updatePrice_Click(object sender, RoutedEventArgs e)
        {
            insurance = Convert.ToDouble(insurancePolicy.Text);
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }
    }
}
=======
﻿using System;
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
        double basePrice = 0; 
        double additionalPrice = 0;
        double insurance = 0;
        MainWindow mainW;
        
        public BrandWindow(MainWindow window)
        {
            InitializeComponent();
            mainW = window;
            FinalPrice.brandPrice = 0;
            price.Content = FinalPrice.enginePrice + "€";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FinalPrice.brandPrice = basePrice + additionalPrice + insurance;
            mainW.price.Content = FinalPrice.brandPrice + FinalPrice.enginePrice + "€";
            this.Close();
        }

        private void fiat_Checked(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            basePrice = 30000;
            price.Content = FinalPrice.enginePrice + basePrice + "€";
        }

        private void ford_Checked(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            basePrice = 50000;
            price.Content = FinalPrice.enginePrice + basePrice + "€";
        }

        private void ferrari_Checked(object sender, RoutedEventArgs e)
        {
            UncheckAll();
            basePrice = 120000;
            price.Content = FinalPrice.enginePrice + basePrice + "€";
        }

        private void steeringWheel_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 100;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void steeringWheel_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 100;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void seats_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 300;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void seats_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 300;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void drive_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 1000;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void drive_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 1000;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void sunroof_Checked(object sender, RoutedEventArgs e)
        {
            additionalPrice += 800;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void sunroof_Unchecked(object sender, RoutedEventArgs e)
        {
            additionalPrice -= 800;
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }

        private void UncheckAll()
        {
            steeringWheel.IsChecked = false;
            seats.IsChecked = false;
            drive.IsChecked = false;
            sunroof.IsChecked = false;
            insurance = 0;
            insurancePolicy.Text = "0";
        }

        private void updatePrice_Click(object sender, RoutedEventArgs e)
        {
            insurance = Convert.ToDouble(insurancePolicy.Text);
            price.Content = FinalPrice.enginePrice + basePrice + additionalPrice + insurance + "€";
        }
    }
}
>>>>>>> 01590052a1a6befa86d58448fd0976e2694a4c46
