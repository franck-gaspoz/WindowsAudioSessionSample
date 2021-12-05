using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using WindowsAudioSession.Components;
using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.UI.SoundWave
{
    public class SoundWaveDrawer : ISoundCaptureHandler
    {
        public bool IsStarted { get; protected set; }

        public double Margin { get; set; } = 8;

        public double Resolution { get; set; } = 10;

        public Brush LineBrush { get; set; } = Brushes.White;

        readonly Canvas _canvas;
        SoundSampleProvider _soundSampleProvider;

        Line[] _lines;
        int _lastLinesCount = -1;

        public SoundWaveDrawer(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void AttachTo(SoundSampleProvider soundSampleProvider)
        {
            _soundSampleProvider = soundSampleProvider;
        }

        public void HandleTick()
        {
            if (_soundSampleProvider == null || !IsStarted) return;

            try
            {
                var x0 = Margin;
                var y0 = Margin;
                var width = _canvas.ActualWidth;
                var height = _canvas.ActualHeight;
                Draw(x0, y0, width, height, ref _soundSampleProvider.SoundSampleData);

            } catch (Exception ex)
            {
                Stop();
                UIHelper.ShowError(
                    ExceptionHelper.BuildException(ex));
            }
        }

        private void Draw(
            double x0, 
            double y0, 
            double width, 
            double height, 
            ref float[] soundSampleData
            )
        {
            var drawWidth = width - 2d * Margin;
            //var columnWidth = drawWidth / soundSampleData.Length;

            var linesCount = (int)Math.Ceiling(drawWidth / Resolution);
            if (linesCount != _lastLinesCount && _lastLinesCount != -1)
                ResetLines();

            if (_lines == null)
            {
                _lines = new Line[linesCount];
                _lastLinesCount = linesCount;
                for (var i = 0; i < linesCount; i++)
                {
                    var line = new Line
                    {
                        Stroke = LineBrush
                    };
                    _lines[i] = line;
                    _ = _canvas.Children.Add(line);
                }
            }

            var x = x0;
            for (var i = 0; i < linesCount; i++) {

            }

        }

        void ResetLines()
        {
            if (_lines!=null)
            {
                foreach (var line in _lines)
                    _canvas.Children.Remove(line);
            }
            _lines = null;
        }

        public void Start()
        {
            if (IsStarted) return;
            ResetLines();
            IsStarted = true;
        }

        public void Stop()
        {
            if (!IsStarted) return;
            ResetLines();
            IsStarted = false;
        }
    }
}
