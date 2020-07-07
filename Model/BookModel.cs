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
            set { }
        }

        public string Author
        {
            get { return author; }
            set { }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public Book(string title, string author, int quantity, double price)
        {
            this.title = title;
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
