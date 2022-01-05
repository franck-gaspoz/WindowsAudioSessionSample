using System;

using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.FFT
{
    /// <summary>
    /// fft peak analyzer
    /// </summary>
    public class FFTPeakAnalyzer : IFFTPeakAnalyzer, IAudioPlugin
    {
        int _barsCount;
        /// <inheritdoc/>
        public int BarsCount
        {
            get => _barsCount;
            set
            {
                _barsCount = value;
                SpectrumPeakData = new double[_barsCount];
            }
        }

        /// <inheritdoc/>
        public IFFTAnalyzer FFTAnalyzer { get; set; }

        /// <inheritdoc/>
        public double[] SpectrumPeakData { get; protected set; }

        /// <inheritdoc/>
        public double DecayStep { get; set; } = 4d;

        /// <inheritdoc/>
        public void HandleTick()
        {
            for (var i = 0; i < FFTAnalyzer.SpectrumData.Length; i++)
            {
                var peakValue = SpectrumPeakData[i];
                var newValue = FFTAnalyzer.SpectrumData[i];

                if (newValue < peakValue)
                {
                    peakValue -= DecayStep;
                    peakValue = Math.Max(0, peakValue);
                }

                if (newValue > peakValue)
                {
                    peakValue = newValue;
                }

                SpectrumPeakData[i] = peakValue;
            }
        }

        /// <inheritdoc/>
        public void Start()
        {
            Reset();
        }

        /// <inheritdoc/>
        public void Stop()
        {
            Reset();
        }

        /// <inheritdoc/>
        void Reset()
        {
            for (var x = 0; x < BarsCount; x++) SpectrumPeakData[x] = 0;
        }
    }
}
