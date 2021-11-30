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

namespace lab7
{
    /// <summary>
    /// Interaction logic for WindowAddBook.xaml
    /// </summary>
    public partial class WindowAddBook : Window
    {
        MainWindow mainWindow;
        public WindowAddBook(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.idBook += 1;
            List<Book> booksList = (List<Book>)mainWindow.books.ItemsSource;
            booksList.Add(new Book() { Title = addTitle.Text, Author = addAuthor.Text, Id = mainWindow.idBook, WhoRented = "-" });
            mainWindow.books.ItemsSource = booksList;
            mainWindow.books.Items.Refresh();
            this.Close();
        }
    }
}
