using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuScaleApp.Model;
using System.Collections.ObjectModel;
using System.Net;

namespace NuScaleApp.ViewModel
{
    public class BookViewModel
    {
        public ObservableCollection<Book> Books
        {
            get;
            set;
        }

        public void LoadBooks()
        {
            // XElement bookDatabase = XElement.Load(@"NuScaleApp\bookDatabase.xml");
            ObservableCollection<Book> bookDatabase = new ObservableCollection<Book>();
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


            string searchDemoAuthor = "1";
            string searchDemoTitle = "Title";
            int searchDemoQuantity = 0;
            int searchDemoPrice = 100;
            IEnumerable<Book> bookQuery =
                from item in bookDatabase
                where item.Author.Contains(searchDemoAuthor)
                    && item.Title.Contains(searchDemoTitle)
                    && item.Quantity >= (searchDemoQuantity)
                    && item.Price <= (searchDemoPrice)
                select item;

            ObservableCollection<Book> filteredBooks = new ObservableCollection<Book>();

            foreach (Book book in bookQuery)
                filteredBooks.Add(book);

            Books = filteredBooks;
        }
    }
}
