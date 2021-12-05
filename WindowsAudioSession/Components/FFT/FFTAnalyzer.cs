using System;

using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public class FFTAnalyzer : ISoundCaptureHandler
    {
        readonly int _barsCount;
        readonly FFTProvider _fftProvider;

        public double[] SpectrumData;

        public FFTAnalyzer(
            FFTProvider fftProvider,
            int barsCount)
        {
            _fftProvider = fftProvider;
            _barsCount = barsCount;
            SpectrumData = new double[_barsCount];
        }

        public void HandleTick()
        {
            if (!_fftProvider.IsFFTAvailable) return;

            var b0 = 0;
            var _bufferLastIndex = _fftProvider.FFTLength.ToBufferSize() - 1;

            for (var x = 0; x < _barsCount; x++)
            {
                double peak = 0;
                var b1 = (int)Math.Pow(2, x * 10.0 / (_barsCount - 1));
                if (b1 > _bufferLastIndex) b1 = _bufferLastIndex;
                if (b1 <= b0) b1 = b0 + 1;
                for (; b0 < b1; b0++)
                {
                    if (peak < _fftProvider.FFT[1 + b0])
                        peak = _fftProvider.FFT[1 + b0];
                }
                var y = (Math.Sqrt(peak) * 3 * 255) - 4;
                if (y > 255) y = 255;
                if (y < 0) y = 0;

                SpectrumData[x] = y;
            }
        }

        void Reset()
        {
            if (SpectrumData != null)
                for (var x = 0; x < _barsCount; x++) SpectrumData[x] = 0;
        }

        public void Start()
        {
            Reset();
        }

        public void Stop()
        {
            Reset();
        }
    }
}
