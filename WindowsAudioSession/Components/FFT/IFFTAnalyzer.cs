﻿using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTAnalyzer : ISoundCaptureHandler
    {
        IFFTProvider FFTProvider { get; set; }

        double[] SpectrumData { get; }

        int BarsCount { get; set; }
    }
}
