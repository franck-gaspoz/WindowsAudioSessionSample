using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    public class FFTDrawer : ISoundCaptureHandler
    {
        readonly Canvas _canvas;
        FFTAnalyzer _fftAnalyser;

        public double Margin { get; set; } = 8;

        public double WidthPercent { get; set; } = 100;

        int[] _lastBarSizes;
        Rectangle[] _bars;

        readonly GradientBrush BarBrush;

        public FFTDrawer(Canvas canvas)
        {
            _canvas = canvas;

            var gradients = new GradientStopCollection(new List<GradientStop>()
            {
                new GradientStop(Colors.Red,0),
                new GradientStop(Colors.Orange,0.1),
                new GradientStop(Colors.Yellow,0.2),
                new GradientStop(Colors.LightGreen,0.3),
                new GradientStop(Colors.Green,0.6),
                new GradientStop(Colors.DodgerBlue,0.8),
                new GradientStop(Colors.Cyan,0.90),
            });
            BarBrush = new LinearGradientBrush(gradients,90d);
        }

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
            var barWidth = (width - 2 * Margin) / barCount;

            if (_lastBarSizes == null)
            {
                _lastBarSizes = new int[barCount];
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
                var y_top = y0 + height - Margin - barHeight;

                var bar = _bars[i];

                Canvas.SetLeft(bar, x);
                //Canvas.SetLeft(_bars[i], Math.Ceiling(x));

                //bar.Width = barWidth * WidthPercent / 100d;
                bar.Width = Math.Ceiling(barWidth * WidthPercent / 100d);

                Canvas.SetTop(bar, y_top);
                bar.Height = barHeight;

                x += barWidth;
            }
        }

        void ResetBars()
        {
            _canvas.Children.Clear();
            _lastBarSizes = null;
        }

        public void HandleTick()
        {
            if (_fftAnalyser == null) return;

            var x0 = Margin;
            var y0 = Margin;
            var width = _canvas.ActualWidth - Margin;
            var height = _canvas.ActualHeight - Margin;

            Draw(x0, y0, width, height, ref _fftAnalyser.SpectrumData);
        }

        public void Start()
        {

        }

        public void Stop()
        {
            ResetBars();
        }

    }
}
