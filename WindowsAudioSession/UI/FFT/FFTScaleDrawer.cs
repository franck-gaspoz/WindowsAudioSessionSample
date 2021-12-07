using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

using WPFUtilities.ComponentModel.ValidationAttributes;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// FFTControl view extension: add a drawer to the control
    /// <para>must be added before control is constructed, thus is done by the control</para>
    /// </summary>
    public class FFTScaleDrawer : IFFTScaleDrawer
    {
        public Brush LineBrush { get; set; } = Brushes.DarkGray;

        public double LineOpacity { get; set; } = 0.5d;

        IFFTControl _fftControl;

        [OfType(typeof(FrameworkElement))]
        public IFFTControl FFTControl
        {
            get => _fftControl;
            set
            {
                _fftControl = value;
                var frameworkElement = (FrameworkElement)FFTControl;
                frameworkElement.SizeChanged += (o, e) => FFTControl_SizeChanged();
                frameworkElement.Loaded += (o, e) => FFTControl_SizeChanged();
            }
        }

        readonly List<Line> _lines = new List<Line>();

        private void FFTControl_SizeChanged()
        {
            var drawPane = _fftControl.GetDrawingSurface();
            foreach (var line in _lines)
                drawPane.Children.Remove(line);

            if (!_fftControl.ShowScaleLines)
                return;

            // 0hz -> 20khz (freq sample / 2)
            var margin = _fftControl.FFTDrawer == null ? 0
                : _fftControl.FFTDrawer.Margin;
            var verticalLinesCount = 20;
            var verticalLinesCountSpacing = (drawPane.ActualWidth - 2d * margin) / verticalLinesCount;
            var x = margin;
            var height = drawPane.ActualHeight;
            for (var i = 0; i < verticalLinesCount; i++)
            {
                var line = new Line()
                {
                    X1 = x,
                    X2 = x,
                    Y1 = margin,
                    Y2 = height - margin,
                    Stroke = LineBrush,
                    Opacity = LineOpacity
                };
                _lines.Add(line);
                _ = drawPane.Children.Add(line);
                x += verticalLinesCountSpacing;
            }
        }
    }
}
