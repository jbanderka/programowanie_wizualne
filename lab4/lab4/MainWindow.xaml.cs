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
using System.Drawing.Imaging;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap bitmap;
        BitmapImage bitmapimage;
        int flipped = 1;
        bool onlyGreen = false;
        BitmapImage savedImage;

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
                Bitmap btmp = new Bitmap(outStream);

                return new Bitmap(btmp);
            }
        }

        private BitmapImage Bitmap2BitmapImage()
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                RotateTransform rotate = img.LayoutTransform as RotateTransform;
                rotate = new RotateTransform(0, 0, 0);
                img.LayoutTransform = rotate;
                Uri fileUri = new Uri(openFileDialog.FileName);
                bitmapimage = new BitmapImage(fileUri);
                savedImage = bitmapimage;
                bitmap = BitmapImage2Bitmap(bitmapimage);
                img.Source = bitmapimage;
            }
        }

        private void mirror_Click(object sender, RoutedEventArgs e)
        {
            if(bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                bitmapimage = Bitmap2BitmapImage();
                img.Source = bitmapimage;
                flipped *= -1;
            }
        }

        private void turn_Click(object sender, RoutedEventArgs e)
        {
            if(bitmap != null)
            {
                RotateTransform rotate = img.LayoutTransform as RotateTransform;
                if (rotate == null)
                {
                    if(flipped == 1)
                    {
                        rotate = new RotateTransform(-90, 0, 0);
                    }
                    if(flipped == -1)
                    {
                        rotate = new RotateTransform(90, 0, 0);
                    }
                    img.LayoutTransform = rotate;
                }
                else
                {
                    if (flipped == 1)
                    {
                        rotate.Angle -= 90;
                    }
                    if (flipped == -1)
                    {
                        rotate.Angle += 90;
                    }
                }
            }
        }

        private void green_Click(object sender, RoutedEventArgs e)
        {
            if(bitmap != null)
            {
                if(onlyGreen)
                {
                    bitmap = BitmapImage2Bitmap(savedImage);
                    onlyGreen = false;
                }
                else
                {
                    System.Drawing.Color c;
                    for (int i = 0; i < bitmap.Width; i++)
                    {
                        for (int j = 0; j < bitmap.Height; j++)
                        {
                            c = bitmap.GetPixel(i, j);
                            if (c.R < 50 && c.G < 150 && c.B < 50)
                            {
                                c = System.Drawing.Color.FromArgb(255, 255, 255);
                                bitmap.SetPixel(i, j, c);
                            }
                        }
                    }
                    onlyGreen = true;
                }
                bitmapimage = Bitmap2BitmapImage();
                img.Source = bitmapimage;
            }
        }

        private void neg_Click(object sender, RoutedEventArgs e)
        {
            if(bitmap != null)
            {
                System.Drawing.Color c;
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        c = bitmap.GetPixel(i, j);
                        c = System.Drawing.Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                        bitmap.SetPixel(i, j, c);
                    }
                }
                bitmapimage = Bitmap2BitmapImage();
                img.Source = bitmapimage;
            }
        }
    }
}
