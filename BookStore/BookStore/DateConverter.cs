using System;
using Windows.UI.Xaml.Data;

namespace BookStore
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;
            return $"{date.ToString("dd/MM/yyyy")}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
