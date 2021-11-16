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
                sequenceBox.Selection.Text = noWhiteSpaces;
                allPatterns.Clear();
                choosePattern.SelectedItem = null;
                choosePattern.Items.Clear();
            }
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            Algorithm algorithm = new Algorithm();
            Dictionary<string, int> foundPatterns = algorithm.findPatterns(sequenceBox.Selection.Text, 4);
            foreach (KeyValuePair<string, int> entry in foundPatterns)
            {
                allPatterns.Text += entry.Key + " - " + entry.Value + Environment.NewLine;
                choosePattern.Items.Add(entry.Key);
            }
        }

        private void choosePattern_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                string selectedPattern = e.AddedItems[0].ToString();
                TextRange wholeSequence = new TextRange(sequenceBox.Document.ContentStart, sequenceBox.Document.ContentEnd);
                wholeSequence.ClearAllProperties();
                for (TextPointer start = sequenceBox.Document.ContentStart;
                        start.CompareTo(sequenceBox.Document.ContentEnd) <= 0;
                            start = start.GetNextContextPosition(LogicalDirection.Forward))
                {
                    if (start.CompareTo(sequenceBox.Document.ContentEnd) == 0)
                        break;
                    string tmpString = start.GetTextInRun(LogicalDirection.Forward);
                    int indexOfTmpString = tmpString.IndexOf(selectedPattern);
                    if (indexOfTmpString >= 0)
                    {
                        start = start.GetPositionAtOffset(indexOfTmpString);
                        if (start != null)
                        {
                            TextPointer end = start.GetPositionAtOffset(selectedPattern.Length);
                            TextRange selection = new TextRange(start, end);
                            if (selection.Text == selectedPattern)
                                selection.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.LightPink));
                        }
                    }
                }
            }
        }
    }

    public class Algorithm
    {
        public Algorithm() { }

        public Dictionary<string, int> findPatterns(string sequence, int k)
        {
            string pattern;
            int count;
            Dictionary<string, int> allPatterns = new Dictionary<string, int>();
            for (int i = 0; i < (sequence.Length - k); i++)
            {
                pattern = sequence.Substring(i, k);
                count = patternCount(sequence, pattern);
                if((count > 1) && !allPatterns.ContainsKey(pattern))
                    allPatterns.Add(pattern, count);
            }
            return allPatterns;
        }

        private int patternCount(string sequence, string pattern)
        {
            int count = 0;
            for(int i = 0; i < (sequence.Length - pattern.Length); i++)
            {
                if(sequence.Substring(i, pattern.Length) == pattern)
                    count++;
            }
            return count;
        }
    }
}
