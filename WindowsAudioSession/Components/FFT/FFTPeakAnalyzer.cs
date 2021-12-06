using System;

using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public class FFTPeakAnalyzer : IFFTPeakAnalyzer, ISoundCaptureHandler
    {
        public int BarsCount { get; protected set; }

        public IFFTAnalyzer FFTAnalyzer { get; protected set; }

        public double[] SpectrumPeakData { get; protected set; }

        public double DecayStep { get; set; } = 4d;

        public FFTPeakAnalyzer(
            IFFTAnalyzer fftAnalyzer,
            int barsCount)
        {
            FFTAnalyzer = fftAnalyzer;
            BarsCount = barsCount;
            SpectrumPeakData = new double[BarsCount];
        }

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
            for (var x = 0; x < BarsCount; x++) SpectrumPeakData[x] = 0;
        }
    }
}
