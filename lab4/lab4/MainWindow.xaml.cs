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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Drawing;
using System.Windows.Interop;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap bitmap;
        BitmapImage bitmapimage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            BitmapSource i = Imaging.CreateBitmapSourceFromHBitmap(
                           bitmap.GetHbitmap(),
                           IntPtr.Zero,
                           Int32Rect.Empty,
                           BitmapSizeOptions.FromEmptyOptions());
            return (BitmapImage)i;
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                bitmapimage = new BitmapImage(fileUri);
                bitmap = new Bitmap(bitmapimage.StreamSource);
                img.Source = bitmapimage;
            }
        }

        private void mirror_Click(object sender, RoutedEventArgs e)
        {
            /*Bitmap imgBitmap = BitmapImage2Bitmap(img);
            var flippedImage = new TransformedBitmap(img.Source, new ScaleTransform(-1, 1));*/
        }

        private void turn_Click(object sender, RoutedEventArgs e)
        {
            /*TransformedBitmap myRotatedBitmapSource = new TransformedBitmap();
            myRotatedBitmapSource.BeginInit();
            myRotatedBitmapSource.Source = img.Source;
            myRotatedBitmapSource.Transform = new RotateTransform(90);
            myRotatedBitmapSource.EndInit();*/
        }
    }
}
