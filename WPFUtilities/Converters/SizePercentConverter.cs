using System;
using System.Globalization;
using System.Windows.Data;

using WPFUtilities.ComponentModel;

namespace WPFUtilities.Converters
{
    /// <summary>
    /// convert a size to a double according a percent ratio (0 to 1)
    /// </summary>
    public class SizePercentConverter :
        Singleton<SizePercentConverter>,
        IMultiValueConverter
    {
        /// <summary>
        /// convert a size to a double according a percent ratio (0 to 1)
        /// </summary>
        /// <param name="values">size = values[0], ratio = values[1]</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>the size mul the ratio</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => Math.Max(0, System.Convert.ToDouble(values[0]) * System.Convert.ToDouble(values[1]));

        /// <summary>
        /// convert back
        /// </summary>
        /// <exception cref="NotImplementedException">not implemented</exception>
        /// <param name="value">value</param>
        /// <param name="targetTypes">target types</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
