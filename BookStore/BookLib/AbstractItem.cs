using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace BookLib
{
    //any product in inventory should be derived from abstractItem class
    public abstract class AbstractItem : INotifyPropertyChanged
    {
        private string _title;
        private double _priceAfterDiscount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get => _title; set => _title = (string.IsNullOrEmpty(value) || value.Length > 60) ? throw new Exception() : value; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public Genre GenrE { get; set; }
        public double Price { get; set; }
        public long ISBN { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int Copies { get; set; }
        public virtual string ImagePath { get; set; }
        public string Description { get; set; }
        public BitmapImage ItemImage { get { return new BitmapImage(new Uri(ImagePath)); } }
        public List<DateTime> SellDates { get; set; }
        public bool OnSale { get; set; }
        public double ItemDiscount { get; set; }

        public double PriceAfterDiscount
        {
            get { return _priceAfterDiscount; }
            set
            {
                _priceAfterDiscount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_priceAfterDiscount)));
            }
        }

        //public int ItemSellAmount
        //{
        //    get { return _itemSellAmount; }
        //    set
        //    {
        //        _itemSellAmount = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_itemSellAmount)));
        //    }
        //}
        //protected void OnPropertyChanged(string PropertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        //}


        public AbstractItem(string title, string author, int edition, Genre genre, double price, long isbn, string publisher, DateTime publishDate,
                   int copies, string imagePath, string description)
        {
            SellDates = new List<DateTime>();
            Title = title;
            Author = author;
            Edition = edition;
            GenrE = genre;
            Price = price;
            ISBN = isbn;
            Publisher = publisher;
            PublishDate = publishDate;
            Copies = copies;
            if (imagePath == "")
                imagePath = "ms-appx:///Images/BookCovers/NoCover.jpg";
            else ImagePath = imagePath;
            Description = description;


        }
        //public string ItemType
        //{
        //    get { return GetType().Name; }
        //}
    }
}
