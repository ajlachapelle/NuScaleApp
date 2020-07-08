using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NuScaleApp.Model
{
    public class BookModel
    { }

    public class Book : INotifyPropertyChanged
    {
        private string title;
        private string author;
        private int quantity;
        private double price;

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (author != value)
                {
                    author = value;
                    RaisePropertyChanged("Author");
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    RaisePropertyChanged("Quantity");
                }
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public Book(string title, string author, int quantity, double price)
        {
            // Default string is needed to allow for adding arbitrary books without a defined title/author
            if (title == null)
                this.title = "(No Title)";
            else
                this.title = title;
            if (author == null)
                this.author = "(No Author)";
            else
                this.author = author;

            this.quantity = quantity;
            this.price = price;
        }

        public void updateQuantity(int delta)
        {
            this.quantity += delta;
        }

        public void updatePrice(double newPrice)
        {
            this.price = newPrice;
        }
    }
}
