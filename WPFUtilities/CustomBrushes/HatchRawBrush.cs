using System.Windows;
using System.Windows.Media;

namespace WPFUtilities.CustomBrushes
{
    /// <summary>
    /// a hatch raw brush
    /// </summary>
    public class HatchRawBrush
    {
        /// <summary>
        /// build a new hatch raw brutch
        /// </summary>
        /// <param name="fill">fill brush</param>
        /// <param name="filledRawHeight">height of the filled part</param>
        /// <param name="emptyRawHeight">height of the empty part</param>
        /// <param name="freeze">if true, the result brush is freezed</param>
        /// <returns>a new hatch raw brush</returns>
        public static Brush Create(
            Brush fill,
            double filledRawHeight = 2,
            double emptyRawHeight = 1,
            bool freeze = true)
        {
            var geometryGroup = new GeometryGroup();
            var geometryDrawing = new GeometryDrawing();
            var drawingBrush = new DrawingBrush();

            geometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 1, filledRawHeight)));
            geometryDrawing.Geometry = geometryGroup;
            geometryDrawing.Brush = fill;

            drawingBrush.Viewport = new Rect(0, 0, 1, filledRawHeight);
            drawingBrush.ViewportUnits = BrushMappingMode.Absolute;
            drawingBrush.Viewbox = new Rect(0, 0, 1, filledRawHeight + emptyRawHeight);
            drawingBrush.ViewboxUnits = BrushMappingMode.Absolute;
            drawingBrush.TileMode = TileMode.Tile;

            drawingBrush.Drawing = geometryDrawing;

            if (freeze) drawingBrush.Freeze();

            return drawingBrush;
        }
    }
}
