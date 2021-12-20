using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> listOfSongs = new Dictionary<string, string>();
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private bool currentlyPlaying = false;
        public MainWindow()
        {
            InitializeComponent();

            while(allSongs.Items.IsEmpty)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = true;
                openFile.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
                if (openFile.ShowDialog() == true)
                {
                    foreach (string file in openFile.FileNames)
                    {
                        ListBoxItem song = new ListBoxItem();
                        string songTitle = file.Split('\\').Last();
                        listOfSongs.Add(songTitle, file);
                        song.Content = songTitle;
                        allSongs.Items.Add(song);
                    }
                }
                if(allSongs.Items.IsEmpty)
                {
                    MessageBoxResult result = MessageBox.Show("Nie została wybrana żadna piosenka. Proszę wybierz przynajmniej jedną piosenkę.", 
                        "Brak piosenek", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void playSong_Click(object sender, RoutedEventArgs e)
        {
            if (currentlyPlaying)
            {
                mediaPlayer.Stop();
                currentlyPlaying = false;
            }
            if(allSongs.SelectedItem != null)
            {
                ListBoxItem selectedSong = allSongs.SelectedItem as ListBoxItem;
                mediaPlayer.Open(new Uri(listOfSongs[selectedSong.Content.ToString()]));
                mediaPlayer.Play();
                currentlyPlaying = true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Proszę wybierz piosenkę do odtworzenia.",
                        "Nie wybrano piosenki", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void stopSong_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            currentlyPlaying = false;
        }
    }
}
