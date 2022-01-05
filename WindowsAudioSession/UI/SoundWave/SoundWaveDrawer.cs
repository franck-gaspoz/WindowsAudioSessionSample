using System;
using System.Windows.Media;
using System.Windows.Shapes;

using WASApiBassNet;
using WASApiBassNet.Components.AudioCapture;
using WASApiBassNet.Components.Sample;

namespace WindowsAudioSession.UI.SoundWave
{
    public class SoundWaveDrawer : ISoundWaveDrawer, IAudioPlugin
    {
        /// <inheritdoc/>
        public IDrawable Drawable { get; set; }

        /// <inheritdoc/>
        public ISoundSampleProvider SoundSampleProvider { get; set; }

        /// <inheritdoc/>
        public bool IsStarted { get; protected set; }

        /// <inheritdoc/>
        public double Margin { get; set; } = 8;

        /// <inheritdoc/>
        public double Resolution { get; set; } = 2;

        /// <inheritdoc/>
        public Brush LineBrush { get; set; } = Brushes.White;

        /// <inheritdoc/>
        public double ScaleFactor { get; set; } = 1.8d;

        Line[] _lines;
        int _lastLinesCount = -1;

        /// <inheritdoc/>
        public void HandleTick()
        {
            if (SoundSampleProvider == null || !IsStarted) return;

            try
            {
                var canvas = Drawable.GetDrawingSurface();
                var x0 = Margin;
                var y0 = Margin;
                var width = canvas.ActualWidth;
                var height = canvas.ActualHeight;
                Draw(
                    x0,
                    y0,
                    width,
                    height,
                    SoundSampleProvider.SoundSampleData,
                    SoundSampleProvider.AvailableLength);

            }
            catch (Exception ex)
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
            float[] soundSampleData,
            int availableLength
            )
        {
            var drawWidth = width - (2d * Margin);
            var drawHeight = height - (2d * Margin);

            var linesCount = (int)Math.Ceiling(drawWidth / Resolution);
            if (linesCount != _lastLinesCount && _lastLinesCount != -1)
                ResetLines();
            var sampleResolution = 8d;
            var maxSampleResolution = availableLength / (double)linesCount;
            sampleResolution = Math.Min(sampleResolution, maxSampleResolution);

            if (_lines == null)
            {
                _lines = new Line[linesCount];
                _lastLinesCount = linesCount;
                for (var i = 0; i < linesCount - 1; i++)
                {
                    var line = new Line
                    {
                        Stroke = LineBrush
                    };
                    _lines[i] = line;
                    _ = Drawable.GetDrawingSurface().Children.Add(line);
                }
            }

            var x = x0;
            double j = 0;
            var scaleFactor = drawHeight / ScaleFactor;
            var centery = y0 + drawHeight / 2d;

            for (var i = 0; i < linesCount - 1; i++)
            {
                var line = _lines[i];
                var j1 = (int)Math.Floor(j);
                line.Y1 = centery + (soundSampleData[j1] * scaleFactor);
                line.X1 = x;
                var j2 = (int)Math.Floor(j + sampleResolution);
                line.Y2 = centery + (soundSampleData[j2] * scaleFactor);
                line.X2 = x + Resolution;
                x += Resolution;
                j += sampleResolution;
            }

        }

        void ResetLines()
        {
            if (_lines != null)
            {
                foreach (var line in _lines)
                    Drawable.GetDrawingSurface().Children.Remove(line);
            }
            _lines = null;
        }

        /// <inheritdoc/>
        public void Start()
        {
            if (IsStarted) return;
            ResetLines();
            IsStarted = true;
        }

        /// <inheritdoc/>
        public void Stop()
        {
            if (!IsStarted) return;
            ResetLines();
            IsStarted = false;
        }
    }
}
