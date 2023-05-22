using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Journal : AbstractItem
    {
        public Journal(string title, string author, int edition, Genre genre, double price, long isbn, string publisher, DateTime publishDate,
                   int copies, string imagePath, string description) : base(title, author, edition, genre, price, isbn, publisher, publishDate,
                    copies, imagePath, description) { }
        public override string ImagePath { get; set; } = "ms-appx:///Images/BookCovers/NoCover2.jpg";
    }
}
