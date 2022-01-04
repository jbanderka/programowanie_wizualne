using Microsoft.Win32;
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
using System.Security.Cryptography;

namespace lab11
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

        private void hideText_Click(object sender, RoutedEventArgs e)
        {
            string textToHide = inputText.Text;
            string keyText = key.Text;
            if(textToHide == "" || keyText == "")
            {
                outputText.Text = "";
                MessageBoxResult result = MessageBox.Show("Brak wprowadzonego tekstu do szyfrowania lub klucza szyfrującego. Wprowadź wszystkie potrzebne dane.",
                        "Brak danych", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (keyText.Length == 16 || keyText.Length == 24 || keyText.Length == 32)
                {
                    using (Aes myAes = Aes.Create())
                    {
                        byte[] encrypted;
                        byte[] aesKey = Encoding.UTF8.GetBytes(keyText);
                        byte[] aesIV = Enumerable.Repeat((byte)0x0, 16).ToArray();

                        myAes.Key = aesKey;
                        myAes.IV = aesIV;
                        ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);
                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    swEncrypt.Write(textToHide);
                                }
                                encrypted = msEncrypt.ToArray();
                            }
                        }
                        outputText.Text = Convert.ToBase64String(encrypted);
                    }
                }
                else
                {
                    outputText.Text = "";
                    MessageBoxResult result = MessageBox.Show("Wprowadzony klucz ma złą długość. Wprowadź klucz o poprawnej długości.",
                        "Zła długość klucza", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }           
        }

        private void saveText_Click(object sender, RoutedEventArgs e)
        {
            string dataToSave = outputText.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files(.txt)|*.txt|all Files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, dataToSave);
        }
    }
}
