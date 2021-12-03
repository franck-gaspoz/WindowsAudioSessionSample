using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPFUtilities.Converters
{
    public class SizePercentRectConverter : IMultiValueConverter
    {
        static SizePercentRectConverter _instance;
        public static SizePercentRectConverter Instance
            => _instance ?? (_instance = new SizePercentRectConverter());

        /// <summary>
        /// parameter 0 : a size
        /// parameter 1 : a percent ratio
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>a rect with sized width, max height</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) 
            => values[0] is double width && values[1] is double percent
                ? new Rect(0, 0, Math.Max(0,width * percent), int.MaxValue)
                : new Rect(0, 0, 0, 0);

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
