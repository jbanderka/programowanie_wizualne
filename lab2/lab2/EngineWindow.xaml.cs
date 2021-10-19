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
    /// Interaction logic for EngineWindow.xaml
    /// </summary>
    public partial class EngineWindow : Window
    {
        MainWindow mainW;
        double priceEngine = 0;
        double pricePower = 0;
        double brandPrice = 0;

        public EngineWindow(MainWindow window)
        {
            InitializeComponent();
            mainW = window;
            brandPrice = FinalPrice.brandPrice;
            FinalPrice.enginePrice = 0;
            price.Content = brandPrice + "€";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FinalPrice.enginePrice = priceEngine + pricePower;
            mainW.price.Content = FinalPrice.brandPrice + FinalPrice.enginePrice + "€";
            this.Close();
        }

        private void petrol_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 1000;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void diesel_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 1200;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void gas_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 1800;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void hybrid_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 2000;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void power_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (power.SelectedIndex == 0)
            {
                pricePower = 50;
            }
            if (power.SelectedIndex == 1)
            {
                pricePower = 100;
            }
            if (power.SelectedIndex == 2)
            {
                pricePower = 200;
            }
            if (power.SelectedIndex == 3)
            {
                pricePower = 450;
            }
            price.Content = brandPrice + priceEngine + pricePower + "€";
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
    /// Interaction logic for EngineWindow.xaml
    /// </summary>
    public partial class EngineWindow : Window
    {
        MainWindow mainW;
        double priceEngine = 0;
        double pricePower = 0;
        double brandPrice = 0;

        public EngineWindow(MainWindow window)
        {
            InitializeComponent();
            mainW = window;
            brandPrice = FinalPrice.brandPrice;
            FinalPrice.enginePrice = 0;
            price.Content = brandPrice + "€";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FinalPrice.enginePrice = priceEngine + pricePower;
            mainW.price.Content = FinalPrice.brandPrice + FinalPrice.enginePrice + "€";
            this.Close();
        }

        private void petrol_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 1000;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void diesel_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 1200;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void gas_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 1800;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void hybrid_Checked(object sender, RoutedEventArgs e)
        {
            power.Text = string.Empty;
            priceEngine = 2000;
            price.Content = brandPrice + priceEngine + "€";
        }

        private void power_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (power.SelectedIndex == 0)
            {
                pricePower = 50;
            }
            if (power.SelectedIndex == 1)
            {
                pricePower = 100;
            }
            if (power.SelectedIndex == 2)
            {
                pricePower = 200;
            }
            if (power.SelectedIndex == 3)
            {
                pricePower = 450;
            }
            price.Content = brandPrice + priceEngine + pricePower + "€";
        }
    }
}
>>>>>>> 01590052a1a6befa86d58448fd0976e2694a4c46
