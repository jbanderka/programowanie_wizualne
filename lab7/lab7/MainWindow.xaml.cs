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

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int idReader = 0;
        // public List<Reader> allReaders;
        public int idBook = 0;
        // public List<Book> allBooks;
        public MainWindow()
        {
            InitializeComponent();
            readers.ItemsSource = new List<Reader>();
            books.ItemsSource = new List<Book>();
        }

        private void AddReader_Click(object sender, RoutedEventArgs e)
        {
            WindowAddReader windowAddReader = new WindowAddReader(this);
            windowAddReader.Show();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            WindowAddBook windowAddBook = new WindowAddBook(this);
            windowAddBook.Show();
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            if(readers.SelectedIndex < 0 || books.SelectedIndex < 0)
            {
                MessageBox.Show("W celu wypożyczenia książki należy zaznaczyć zarówno wypożyczającego jak i książkę do wypożyczenia!", 
                    "Błąd wypożyczania", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Reader who = (Reader)readers.Items[readers.SelectedIndex];
                Book what = (Book)books.Items[books.SelectedIndex];
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Reader
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Id { get; set; }
        public bool CheckedOut { get; set; }
        public int WhoRented { get; set; }
    }
}
