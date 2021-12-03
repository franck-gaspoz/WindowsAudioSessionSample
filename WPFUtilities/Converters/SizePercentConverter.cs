using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFUtilities.Converters
{
    public class SizePercentConverter : IMultiValueConverter
    {
        static SizePercentConverter _instance;
        public static SizePercentConverter Instance
            => _instance ?? (_instance = new SizePercentConverter());

        /// <summary>
        /// parameter 0 : a size
        /// parameter 1 : a percent ratio
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => Math.Max(0,System.Convert.ToDouble(values[0]) * System.Convert.ToDouble(values[1]));

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
