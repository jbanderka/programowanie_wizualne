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
using Microsoft.Win32;

namespace lab5
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

        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog sequenceFile = new OpenFileDialog();
            if (sequenceFile.ShowDialog() == true)
            {
                string seqText = File.ReadAllText(sequenceFile.FileName);
                string noWhiteSpaces = String.Concat(seqText.Where(c => !Char.IsWhiteSpace(c)));
                sequenceBox.Text = noWhiteSpaces;
            }
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            Algorithm algorithm = new Algorithm(sequenceBox.Text, 3);
        }
    }

    public class Algorithm
    {
        public Algorithm(string sequence, int k)
        {
            findPatterns(sequence, k);
        }

        private void findPatterns(string sequence, int k)
        {
            string foundPatterns = "";

        }
    }
}
