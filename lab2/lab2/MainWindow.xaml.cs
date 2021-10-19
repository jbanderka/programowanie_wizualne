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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BrandWindow brandWindow = new BrandWindow(this);
            brandWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EngineWindow engineWindow = new EngineWindow(this);
            engineWindow.Show();
        }

        private void clearPrice_Click(object sender, RoutedEventArgs e)
        {
            FinalPrice.enginePrice = 0;
            FinalPrice.brandPrice = 0;
            price.Content = "0€";
        }
    }

    public static class FinalPrice
    {
        public static double enginePrice { get; set; }
        public static double brandPrice { get; set; }
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BrandWindow brandWindow = new BrandWindow(this);
            brandWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EngineWindow engineWindow = new EngineWindow(this);
            engineWindow.Show();
        }

        private void clearPrice_Click(object sender, RoutedEventArgs e)
        {
            FinalPrice.enginePrice = 0;
            FinalPrice.brandPrice = 0;
            price.Content = "0€";
        }
    }

    public static class FinalPrice
    {
        public static double enginePrice { get; set; }
        public static double brandPrice { get; set; }
    }
}
>>>>>>> 01590052a1a6befa86d58448fd0976e2694a4c46