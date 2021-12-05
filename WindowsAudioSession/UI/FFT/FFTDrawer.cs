using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

using WPFUtilities.CustomBrushes;

namespace WindowsAudioSession.UI.FFT
{
    public class FFTDrawer : ISoundCaptureHandler
    {
        readonly Canvas _canvas;
        FFTAnalyzer _fftAnalyser;

        public double Margin { get; set; } = 8;

        public double WidthPercent { get; set; } = 100;

        Rectangle[] _bars;

        public Brush BarBrush { get; set; } = SpectrumBrush.Build();

        public bool IsStarted { get; protected set; }

        public FFTDrawer(Canvas canvas) => _canvas = canvas;

        public void AttachTo(FFTAnalyzer fftAnalyzer)
        {
            _fftAnalyser = fftAnalyzer;
        }

        public void Draw(
            double x0,
            double y0,
            double width,
            double height,
            ref double[] barSizes
            )
        {
            var barCount = barSizes.Length;
            var barMaxWidth = (width - (2d * Margin)) / barCount;
            var barWidth = barMaxWidth * WidthPercent / 100d;

            if (_bars == null)
            {
                _bars = new Rectangle[barCount];
                for (var i = 0; i < barCount; i++)
                {
                    var bar = new Rectangle();
                    _bars[i] = bar;
                    bar.Fill = BarBrush;
                    _ = _canvas.Children.Add(bar);
                }
            }

            var x = x0;

            for (var i = 0; i < barCount; i++)
            {
                var barHeight = Math.Max(0, barSizes[i] * (height - 2 * Margin) / 255d);
                var y_top = y0 + height - 2 * Margin - barHeight;

                var bar = _bars[i];

                Canvas.SetLeft(bar, x);
                //Canvas.SetLeft(_bars[i], Math.Ceiling(x));

                //bar.Width = barWidth * WidthPercent / 100d;
                bar.Width = Math.Ceiling(barWidth * WidthPercent / 100d);

                Canvas.SetTop(bar, y_top);
                bar.Height = barHeight;

                x += barMaxWidth;
            }
        }

        void ResetBars()
        {
            if (_bars != null)
                foreach (var bar in _bars)
                    _canvas.Children.Remove(bar);
            _bars = null;
        }

        public void HandleTick()
        {
            if (_fftAnalyser == null || !IsStarted) return;

            try
            {
                var x0 = Margin;
                var y0 = Margin;
                var width = _canvas.ActualWidth;
                var height = _canvas.ActualHeight;

                Draw(x0, y0, width, height, ref _fftAnalyser.SpectrumData);
            }
            catch (Exception ex)
            {
                Stop();
                UIHelper.ShowError(ex);
            }
        }

        public void Start()
        {
            ResetBars();
            IsStarted = true;
        }

        public void Stop()
        {
            ResetBars();
            IsStarted = false;
        }

    }
}
