using System.Collections.Generic;
using System.Windows.Media;

namespace WPFUtilities.CustomBrushes
{
    /// <summary>
    /// a spectrum brush
    /// </summary>
    public class SpectrumBrush
    {
        /// <summary>
        /// builds a new spectrum brush
        /// </summary>
        /// <param name="freeze">if true, the result brush is freezed</param>
        /// <returns>a new spectrum brush</returns>
        public static Brush Create(
            bool freeze = true)
        {
            var brush = new LinearGradientBrush(
                new GradientStopCollection(
                    new List<GradientStop>()
                    {
                        new GradientStop(Colors.Red,0),
                        new GradientStop(Colors.Orange,0.1),
                        new GradientStop(Colors.Yellow,0.2),
                        new GradientStop(Colors.LightGreen,0.3),
                        new GradientStop(Colors.Green,0.6),
                        new GradientStop(Colors.DodgerBlue,0.8),
                        new GradientStop(Colors.Cyan,0.90),
                    }),
                90d);

            if (freeze) brush.Freeze();

            return brush;
        }
    }
}
