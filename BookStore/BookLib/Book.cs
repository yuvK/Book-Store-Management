using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace BookLib
{
    public class Book : AbstractItem
    {
        public Book(string title, string author, int edition, Genre genre, double price, long isbn, string publisher, DateTime publishDate,
                   int copies, string imagePath, string description) : base(title, author, edition, genre, price, isbn, publisher, publishDate,
                    copies, imagePath, description) { }

        public override string ImagePath { get; set; } = "ms-appx:///Images/BookCovers/NoCover.jpg";
    }
}
