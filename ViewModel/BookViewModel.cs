using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuScaleApp.Model;
using System.Collections.ObjectModel;
using System.Net;
using System.ComponentModel;

namespace NuScaleApp.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        public string titleFilter;
        public string authorFilter;
        public int quantityFilter;
        public double priceFilter;

        public string TitleFilter
        {
            get { return titleFilter; }
            set
            {
                if (titleFilter != value)
                {
                    titleFilter = value;
                    //NotifyPropertyChanged(nameof(TitleFilter));
                }
            }
        }
        public string AuthorFilter
        {
            get { return authorFilter; }
            set
            {
                if (authorFilter != value)
                {
                    authorFilter = value;
                    //NotifyPropertyChanged(nameof(AuthorFilter));
                }
            }
        }
        public int QuantityFilter
        {
            //get { return quantityFilter; }
            set { }
        }
        public double PriceFilter
        {
            //get { return priceFilter; }
            set { }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public ObservableCollection<Book> bookDatabase;
        public ObservableCollection<Book> Books
        {
            get;
            set;
        }

        public BookViewModel()
        {
            // XElement bookDatabase = XElement.Load(@"NuScaleApp\bookDatabase.xml");
            bookDatabase = new ObservableCollection<Book>();
            bookDatabase.Add(new Book("Title1", "Author1", 0, .99));
            bookDatabase.Add(new Book("Title2", "Author2", 250, 10.89));
            bookDatabase.Add(new Book("Title3", "Author3", 36, .99));
            bookDatabase.Add(new Book("Title4", "Author4", 35, .99));
            bookDatabase.Add(new Book("Title5", "Author5", 35, .99));
            bookDatabase.Add(new Book("Title6", "Author6", 23, 1));
            bookDatabase.Add(new Book("Title7", "Author7", 54, .99));
            bookDatabase.Add(new Book("Title8", "Author8", 500, 35));
            bookDatabase.Add(new Book("Title9", "Author9", 50, 30));
            bookDatabase.Add(new Book("Title10", "Author10", 1, 59.99));

            titleFilter = "";
            authorFilter = "";
            quantityFilter = 0;
            priceFilter = 100;
        }

        public void LoadBooks()
        {
            IEnumerable<Book> bookQuery =
            from item in bookDatabase
            where item.Author.Contains(authorFilter)
                && item.Title.Contains(titleFilter)
                && item.Quantity >= (quantityFilter)
                && item.Price <= (priceFilter)
            select item;

            ObservableCollection<Book> filteredBooks = new ObservableCollection<Book>();

            foreach (Book book in bookQuery)
                filteredBooks.Add(book);

            Books = filteredBooks;
        }

        public void AddBook(string title, string author, int quantity, double price)
        {
            bookDatabase.Add(new Book(title, author, quantity, price));
            LoadBooks();
        }
        public void RemoveBook(Book book)
        {
            bookDatabase.Remove(book);
            LoadBooks();
        }
    }
}
