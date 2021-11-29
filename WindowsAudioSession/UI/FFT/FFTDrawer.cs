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
        readonly FFTAnalyzer _fftAnalyser;

        public double Margin { get; set; } = 8;

        public double WidthPercent { get; set; } = 100;

        int[] _lastBarSizes;
        Rectangle[] _bars;

        readonly GradientBrush BarBrush;

        public FFTDrawer(
            Canvas canvas,
            FFTAnalyzer fftAnalyser)
        {
            _canvas = canvas;
            _fftAnalyser = fftAnalyser;

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
            BarBrush = new LinearGradientBrush(gradients);
        }

        public void Draw(
            double x0,
            double y0,
            double width,
            double height,
            ref int[] barSizes
            )
        {
            var barCount = barSizes.Length;
            var barWidth = width / barCount;

            if (_lastBarSizes == null)
            {
                _lastBarSizes = new int[barCount];
                _bars = new Rectangle[barCount];
                for (var i = 0; i < barCount; i++)
                {
                    var bar = new Rectangle(); ;
                    _bars[i] = bar;
                    bar.Fill = BarBrush;
                    //bar.Width = barWidth * WidthPercent / 100d;
                    bar.Width = Math.Ceiling(barWidth * WidthPercent / 100d);
                    _ = _canvas.Children.Add(bar);
                }
            }

            var x = x0;

            for (var i = 0; i < barCount; i++)
            {
                var y_top = y0 + height - barSizes[i];

                Canvas.SetLeft(_bars[i], x);
                //Canvas.SetLeft(_bars[i], Math.Ceiling(x));
                Canvas.SetTop(_bars[i], y_top);
                _bars[i].Height = barSizes[i];

                x += barWidth;
            }
        }

        public void HandleTick()
        {
            var x0 = Margin;
            var y0 = Margin;
            var width = _canvas.Width - Margin;
            var height = _canvas.Height - Margin;

            Draw(x0, y0, width, height, ref _fftAnalyser.Spectrumdata);
        }

        public void Start()
        {

        }

        public void Stop()
        {
            _canvas.Children.Clear();
        }

    }
}
