using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTAnalyzer : ISoundCaptureHandler
    {
        IFFTProvider FFTProvider { get; }

        double[] SpectrumData { get; }

        int BarsCount { get; }
    }
}
