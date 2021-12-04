using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFUtilities.Converters
{
    public class BooleanToVisibilityConverter
        : IValueConverter
    {
        static BooleanToVisibilityConverter _instance;
        public static BooleanToVisibilityConverter Instance
            => _instance ?? (_instance = new BooleanToVisibilityConverter());

        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            try
            {
                var visibility = (bool)value;
                return visibility ?
                    Visibility.Visible :
                    ((parameter is Visibility notVisibleVisibility) ?
                        notVisibleVisibility :
                        Visibility.Collapsed);
            }
            catch
            {
                return Visibility.Collapsed;
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