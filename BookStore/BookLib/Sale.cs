using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace BookLib
{
    //sale item for reports views
    public class Sale
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public bool OnSale { get; set; }
        public double ItemDiscount { get; set; }
        public string ItemType { get; set; }
        public DateTime SaleTime { get; set; }
        public Sale()
        {
            SaleTime = DateTime.Now;
        }
    }
}
