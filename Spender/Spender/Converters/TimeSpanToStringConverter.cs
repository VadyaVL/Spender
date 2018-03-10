using System;
using System.Globalization;
using Xamarin.Forms;

namespace Spender.Converters
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is TimeSpan duration)
            {
                return duration.ToString(@"dd\.hh\:mm\:ss");
            }

            return "Not valid param";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}