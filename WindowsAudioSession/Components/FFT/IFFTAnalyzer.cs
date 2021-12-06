using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTAnalyzer : ISoundCaptureHandler
    {
        double[] SpectrumData { get; }
    }
}
