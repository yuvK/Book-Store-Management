using BookLib;
using System;
using System.Collections.Generic;

namespace StoreManager
{
    public enum DiscountBy
    {
        Title,
        Author,
        Genre,
        Publisher
    };
    public class Discount
    {
        private int _discountPrecentage;
        public DateTime AddedDay { get; set; }
        public string Name { get; set; }
        public List<AbstractItem> ItemsOnSale { get; set; }
        public DiscountBy DiscountBy { get; set; }
        public int DiscountPercentage
        {
            get
            {
                return _discountPrecentage;
            }
            set
            {
                _discountPrecentage = (value > 0 && value <= 100) ? _discountPrecentage = value : throw new Exception("Precantage is not on valid range(1 to 100)");
            }
        }

        public Discount(DiscountBy discountBy, string name, int discountPercentage)
        {
            DiscountBy = discountBy;
            Name = name;
            DiscountPercentage = discountPercentage;
            AddedDay = DateTime.Today;
            ItemsOnSale = new List<AbstractItem>();
        }
    }
}
