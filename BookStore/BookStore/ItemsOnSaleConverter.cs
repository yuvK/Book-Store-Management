using BookLib;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace BookStore
{
    public class ItemsOnSaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            List<AbstractItem> list = value as List<AbstractItem>;
            string s = "";
            foreach (AbstractItem item in list)
            {
                if (item.PriceAfterDiscount > 0)
                    s += $"{item.Title}, Full Price: {item.Price:c}, After discount price: {item.PriceAfterDiscount:c}\n";
                else
                    s += $"{item.Title}, Full Price: {item.Price:c}\n";
            }
            return s;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
