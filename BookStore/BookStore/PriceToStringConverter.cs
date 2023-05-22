using System;
using Windows.UI.Xaml.Data;

namespace BookStore
{
    public class PriceToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Double price = (Double)value;
            return $"{price:c}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
