using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFUtilities.Converters
{
    /// <summary>
    /// converts Rect sizes to a new Rect according a percent ratio (0 to 1). new rect height is int.MaxValue
    /// </summary>
    public class SizePercentRectConverter : IMultiValueConverter
    {
        static SizePercentRectConverter _instance;
        /// <summary>
        /// shared instance
        /// </summary>
        public static SizePercentRectConverter Instance
            => _instance ?? (_instance = new SizePercentRectConverter());

        /// <summary>
        /// convert a size to a double according a percent ratio (0 to 1). new rect height is int.MaxValue
        /// </summary>
        /// <param name="values">rect = values[0], ratio = values[1]</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>a rect with sized width, max height</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => values[0] is double width && values[1] is double percent
                ? new Rect(0, 0, Math.Max(0, width * percent), int.MaxValue)
                : new Rect(0, 0, 0, 0);

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
