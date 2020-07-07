using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuScaleApp.Model;
using System.Collections.ObjectModel;

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
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            books.Add(new Book("Title1", "Author1", 1, .99));

            Books = books;
        }
    }
}
