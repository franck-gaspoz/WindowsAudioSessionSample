using System;

using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public class FFTPeakAnalyzer : ISoundCaptureHandler
    {
        readonly int _barsCount;
        readonly FFTAnalyzer _fftAnalyzer;

        public double[] SpectrumPeakData;

        public double DecayStep { get; set; } = 4d;

        public FFTPeakAnalyzer(
            FFTAnalyzer fftAnalyzer,
            int barsCount)
        {
            _fftAnalyzer = fftAnalyzer;
            _barsCount = barsCount;
            SpectrumPeakData = new double[_barsCount];
        }

        public void HandleTick()
        {
            for (var i = 0; i < _fftAnalyzer.SpectrumData.Length; i++)
            {
                var peakValue = SpectrumPeakData[i];
                var newValue = _fftAnalyzer.SpectrumData[i];

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

        public void Start()
        {
            Reset();
        }

        public void Stop()
        {
            Reset();
        }

        void Reset()
        {
            for (var x = 0; x < _barsCount; x++) SpectrumPeakData[x] = 0;
        }
    }
}
