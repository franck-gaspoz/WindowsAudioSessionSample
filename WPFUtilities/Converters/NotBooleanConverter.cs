using System;
using System.Globalization;
using System.Windows.Data;

using WPFUtilities.ComponentModel;

namespace WPFUtilities.Converters
{
    /// <summary>
    /// converts a boolean to its negated value
    /// </summary>
    public class NotBooleanConverter :
        Singleton<NotBooleanConverter>,
        IValueConverter
    {
        /// <summary>
        /// convert from bool to !bool
        /// </summary>
        /// <param name="value">value, expects a boolean</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>!value. returns false if not a boolean</returns>
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

        /// <summary>
        /// convert from bool to !bool
        /// </summary>
        /// <param name="value">value, expects a boolean</param>
        /// <param name="targetType">expect </param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>!value. returns false if not a boolean</returns>
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
            => Convert(value, targetType, parameter, culture);
    }
}
