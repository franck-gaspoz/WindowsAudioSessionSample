﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WindowsAudioSession.UI.FFT
{
    public class FFTScaleDrawer
    {
        public Brush LineBrush { get; set; } = Brushes.DarkGray;
        public double LineOpacity { get; set; } = 0.5d;

        public FFTControl FFTControl { get; }

        readonly List<Line> _lines = new List<Line>();

        public FFTScaleDrawer(FFTControl fftControl)
        {
            FFTControl = fftControl;
            FFTControl.SizeChanged += (o,e) => FFTControl_SizeChanged();
            FFTControl.Loaded += (o,e) => FFTControl_SizeChanged();
        }

        private void FFTControl_SizeChanged()
        {
            var drawPane = FFTControl.BarGraph;
            foreach (var line in _lines)
                drawPane.Children.Remove(line);

            if (!FFTControl.ShowScaleLines)
                return;

            // 0hz -> 20khz (freq sample / 2)
            var margin = FFTControl.ViewModel.FFTDrawer.Margin;
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