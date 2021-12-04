using System.Windows;
using System.Windows.Media;

namespace WPFUtilities.CustomBrushes
{
    public class HatchRawBrush
    {
        public static Brush Build(
            Brush fill,
            double filledRawHeight = 2,
            double emptyRawHeight = 1)
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

            return drawingBrush;
        }
    }
}
