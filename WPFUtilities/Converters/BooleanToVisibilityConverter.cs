using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFUtilities.Converters
{
    /// <summary>
    /// converts a boolean to a visibility value
    /// </summary>
    public class BooleanToVisibilityConverter
        : IValueConverter
    {
        static BooleanToVisibilityConverter _instance;
        /// <summary>
        /// shared instance
        /// </summary>
        public static BooleanToVisibilityConverter Instance
            => _instance ?? (_instance = new BooleanToVisibilityConverter());

        /// <summary>
        /// convert from bool to Visibility
        /// </summary>
        /// <param name="value">value, expects a boolean</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>Visiblity.Visibile if value is true, Collapsed otherwize returns Collapsed if value is not a Visibility/returns>
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

        /// <summary>
        /// convert back from Visiblity to bool
        /// </summary>
        /// <param name="value">value, expects a visiblity</param>
        /// <param name="targetType">expect </param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>true if visivility is Visible, false otherwize returns false if value is not a boolean/returns>
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            try
            {
                var visibility = (Visibility)value;
                return visibility == Visibility.Visible ? true : false;
            }
            catch
            {
                return false;
            }
        }
    }
}