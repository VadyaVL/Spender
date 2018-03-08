using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace Spender.Converters
{
    /// <summary>
    /// Converting an object to a boolean value.
    /// Checking a string or a list is not empty.
    /// Checking the object is not empty.
    /// Etc...
    /// </summary>
    public class ObjectToBoolConverter : IValueConverter
    {
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Boolean value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return !string.IsNullOrWhiteSpace(str);
            }
            else if (value is ICollection list)
            {
                return list.Count != 0;
            }

            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
