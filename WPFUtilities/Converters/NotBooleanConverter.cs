using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFUtilities.Converters
{
    public class NotBooleanConverter
        : IValueConverter
    {
        static NotBooleanConverter _instance;
        public static NotBooleanConverter Instance
            => _instance ?? (_instance = new NotBooleanConverter());

        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            try
            {
                var v = (bool)value;
                return !v;
            }
            catch
            {
                return false;
            }
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
