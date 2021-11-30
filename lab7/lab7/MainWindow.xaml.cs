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
using System.Xml.Serialization;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int idReader = 0;
        public int idBook = 0;
        public MainWindow()
        {
            InitializeComponent();
            readers.ItemsSource = new List<Reader>();
            books.ItemsSource = new List<Book>();
            MessageBoxResult result = MessageBox.Show("Czy chcesz wczytać dane z pliku?",
                "Odczyt", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                if (openDialog.ShowDialog() == true)
                {
                    string fileData;
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(string));
                    StreamReader reader = new StreamReader(openDialog.FileName);
                    fileData = (string)xmlSerializer.Deserialize(reader);
                    char delim = ';';
                    // splitting two collections
                    string[] collections = fileData.Split(delim, StringSplitOptions.RemoveEmptyEntries);

                    if(collections.Length == 2)
                    {
                        char[] delims = new[] { '\r', '\n' };
                        // reading all readers' entries from XML file
                        string[] readersEntries = collections[0].Split(delims, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string entry in readersEntries)
                        {
                            string[] fields = entry.Split(',');
                            idReader += 1;
                            List<Reader> allReaders = (List<Reader>)readers.ItemsSource;
                            allReaders.Add(new Reader() { Name = fields[0], Surname = fields[1], Id = int.Parse(fields[2]) });
                            readers.ItemsSource = allReaders;
                            readers.Items.Refresh();
                        }
                        // reading all books' entries from XML file
                        string[] booksEntries = collections[1].Split(delims, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string entry in booksEntries)
                        {
                            string[] fields = entry.Split(',');
                            idReader += 1;
                            List<Book> allBooks = (List<Book>)books.ItemsSource;
                            allBooks.Add(new Book() { Title = fields[0], Author = fields[1], Id = int.Parse(fields[2]), 
                                WhoRented = fields[3] });
                            books.ItemsSource = allBooks;
                            books.Items.Refresh();
                        }
                    }  
                }
            }
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
                Book what = (Book)books.Items[books.SelectedIndex];
                if(what.WhoRented == "-")
                {
                    List<Book> booksList = (List<Book>)books.ItemsSource;
                    int whoIndex = readers.SelectedIndex + 1;
                    what.WhoRented = whoIndex.ToString();
                    booksList[books.SelectedIndex] = what;
                    books.ItemsSource = booksList;
                    books.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Ta książka jest już przez kogoś wypożyczona. Wybierz inną książkę lub poczekaj aż ta książka zostanie oddana.", 
                        "Błąd wypożyczania", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if(books.SelectedIndex < 0)
            {
                MessageBox.Show("W celu oddania książki należy zaznaczyć książkę do oddania!",
                    "Błąd oddania", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Book what = (Book)books.Items[books.SelectedIndex];
                if (what.WhoRented != "-")
                {
                    List<Book> booksList = (List<Book>)books.ItemsSource;
                    what.WhoRented = "-";
                    booksList[books.SelectedIndex] = what;
                    books.ItemsSource = booksList;
                    books.Items.Refresh();
                }
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać zawartość?",
                "Zapis", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                StringBuilder dataToSave = new StringBuilder();
                foreach (Reader reader in readers.ItemsSource)
                {
                    string line = string.Format($"{reader.Name},{reader.Surname},{reader.Id}");
                    dataToSave.AppendLine(line);
                }
                dataToSave.AppendLine(";");
                foreach (Book book in books.ItemsSource)
                {
                    string line = string.Format($"{book.Title},{book.Author},{book.Id},{book.WhoRented}");
                    dataToSave.AppendLine(line);
                }
                string data = dataToSave.ToString();
                XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*";
                if (saveDialog.ShowDialog() == true)
                {
                    TextWriter writer = new StreamWriter(saveDialog.FileName);
                    xmlSerializer.Serialize(writer, data);
                    writer.Close();
                }
            }
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
        public string WhoRented { get; set; }
    }
}
