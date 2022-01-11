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
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace lab12
{
    /// <summary>
    /// Interaction logic for ButtonsWindow.xaml
    /// </summary>
    public partial class ButtonsWindow : Window
    {
        public int animal = -1;
        public int level = -1;
        List<int> buttonsNum;
        public List<Animal> animals = new List<Animal>();
        int animalButton = 0;

        DispatcherTimer dispatcherTimer;
        TimeSpan timeSpan;

        public ButtonsWindow(int selectedAnimal, int selectedLevel)
        {
            InitializeComponent();

            animal = selectedAnimal;
            level = selectedLevel;

            // list of animals
            animals.Add(new Animal() { Name = "Mouse", Img = "https://www.goodfreephotos.com/cache/vector-images/mouse-vector-clipart.png" });
            animals.Add(new Animal() { Name = "Fish", Img = "https://clipartcraft.com/images/fish-clipart-nemo-4.png" });
            animals.Add(new Animal() { Name = "Cat", Img = "https://i.pinimg.com/originals/db/28/4a/db284a662aa25166611b8ec09316faf8.jpg" });
            animals.Add(new Animal() { Name = "Crocodile", Img = "https://webstockreview.net/images/crocodile-clipart-croccodile-1.jpg" });

            animalImg.Source = new BitmapImage(new Uri(animals[animal].Img));
            animalImg.Stretch = Stretch.Fill;

            if (level == 0) // Easy
            {
                // hide unimportant buttons
                button1.Visibility = Visibility.Collapsed;
                button2.Visibility = Visibility.Collapsed;
                button3.Visibility = Visibility.Collapsed;
                button4.Visibility = Visibility.Collapsed;
                button5.Visibility = Visibility.Collapsed;
                button6.Visibility = Visibility.Collapsed;
                button10.Visibility = Visibility.Collapsed;
                button11.Visibility = Visibility.Collapsed;
                button15.Visibility = Visibility.Collapsed;
                button16.Visibility = Visibility.Collapsed;
                button20.Visibility = Visibility.Collapsed;
                button21.Visibility = Visibility.Collapsed;
                button22.Visibility = Visibility.Collapsed;
                button23.Visibility = Visibility.Collapsed;
                button24.Visibility = Visibility.Collapsed;
                button25.Visibility = Visibility.Collapsed;

                // add visible buttons to list
                buttonsNum = new List<int>() { 7, 8, 9, 12, 13, 14, 17, 18, 19 };
            }
            else if (level == 1) // Normal
            {
                // hide unimportant buttons
                button5.Visibility = Visibility.Collapsed;
                button10.Visibility = Visibility.Collapsed;
                button15.Visibility = Visibility.Collapsed;
                button20.Visibility = Visibility.Collapsed;
                button21.Visibility = Visibility.Collapsed;
                button22.Visibility = Visibility.Collapsed;
                button23.Visibility = Visibility.Collapsed;
                button24.Visibility = Visibility.Collapsed;
                button25.Visibility = Visibility.Collapsed;

                // add visible buttons to list
                buttonsNum = new List<int>() { 1, 2, 3, 4, 6, 7, 8, 9, 11, 12, 13, 14, 16, 17, 18, 19 };
            }
            else // Hard
            {
                // add all buttons to the list
                buttonsNum = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            }
            animalButton = generateAnimal();

            timeSpan = TimeSpan.FromMilliseconds(3000);

            dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 100), DispatcherPriority.Normal, delegate
            {
                time.Content = timeSpan.ToString("G");
                if (timeSpan == TimeSpan.Zero)
                {
                    dispatcherTimer.Stop();
                    openSummary("wasted");
                }
                timeSpan = timeSpan.Add(TimeSpan.FromMilliseconds(-100));
            }, Application.Current.Dispatcher);

            dispatcherTimer.Start();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int num = 1;
            buttonAction(num, button1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int num = 2;
            buttonAction(num, button2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int num = 3;
            buttonAction(num, button3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int num = 4;
            buttonAction(num, button4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            int num = 5;
            buttonAction(num, button5);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            int num = 6;
            buttonAction(num, button6);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            int num = 7;
            buttonAction(num, button7);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            int num = 8;
            buttonAction(num, button8);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            int num = 9;
            buttonAction(num, button9);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            int num = 10;
            buttonAction(num, button10);
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            int num = 11;
            buttonAction(num, button11);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            int num = 12;
            buttonAction(num, button12);
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            int num = 13;
            buttonAction(num, button13);
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            int num = 14;
            buttonAction(num, button14);
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            int num = 15;
            buttonAction(num, button15);
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            int num = 16;
            buttonAction(num, button16);
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            int num = 17;
            buttonAction(num, button17);
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            int num = 18;
            buttonAction(num, button18);
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            int num = 19;
            buttonAction(num, button19);
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            int num = 20;
            buttonAction(num, button20);
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            int num = 21;
            buttonAction(num, button21);
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            int num = 22;
            buttonAction(num, button22);
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            int num = 23;
            buttonAction(num, button23);
        }

        private void button24_Click(object sender, RoutedEventArgs e)
        {
            int num = 24;
            buttonAction(num, button24);
        }

        private void button25_Click(object sender, RoutedEventArgs e)
        {
            int num = 25;
            buttonAction(num, button25);
        }

        private int generateAnimal()
        {
            Random random = new Random();
            int listIndex = random.Next(buttonsNum.Count);

            return buttonsNum[listIndex];
        }

        private void buttonAction(int currentButton, Button button)
        {
            if (animalButton == currentButton)
            {
                animalImg.Margin = button.Margin;
                animalImg.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Collapsed;

                if (animal == 3)
                {
                    Random random = new Random();
                    int noTimeToDie = random.Next(0, 2);
                    if (noTimeToDie == 0)
                        openSummary("die");
                    else
                        openSummary("win");
                }
                else
                    openSummary("win");                 
                
            }
            else
            {
                button.Visibility = Visibility.Collapsed;
            }
        }

        private void openSummary(string result)
        {
            if (dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Stop();
            }
            SummaryWindow summaryWindow = new SummaryWindow(this, result);
            summaryWindow.Show();

            grid.IsEnabled = false;
        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public string Img { get; set; }
    }
}
