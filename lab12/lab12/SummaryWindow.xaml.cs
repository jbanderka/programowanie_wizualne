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

namespace lab12
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        int animal = -1;
        int level = -1;
        ButtonsWindow btnWindow;
        public SummaryWindow(ButtonsWindow buttonsWindow, string result)
        {
            InitializeComponent();

            animal = buttonsWindow.animal;
            level = buttonsWindow.level;
            btnWindow = buttonsWindow;

            if (result == "win")
            {
                message.Text = "You caught " + buttonsWindow.animals[animal].Name + "!";
                tryAgain.Visibility = Visibility.Collapsed;
                returnButton.Margin = tryAgain.Margin;
            }
            else if (result == "wasted")
            {
                message.Text = "Wasted...";
            }
            else
            {
                message.Text = "You died...";
                tryAgain.Visibility = Visibility.Collapsed;
                returnButton.Margin = tryAgain.Margin;
            }
        }

        private void tryAgain_Click(object sender, RoutedEventArgs e)
        {
            btnWindow.Close();
            ButtonsWindow buttonsWindow = new ButtonsWindow(animal, level);
            buttonsWindow.Show();
            this.Close();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            btnWindow.Close();
            this.Close();
        }
    }
}
