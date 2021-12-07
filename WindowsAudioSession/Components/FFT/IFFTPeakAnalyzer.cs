using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTPeakAnalyzer : IAudioPlugHandler
    {
        IFFTAnalyzer FFTAnalyzer { get; set; }

        double[] SpectrumPeakData { get; }

        double DecayStep { get; set; }

        int BarsCount { get; set; }
    }
}
