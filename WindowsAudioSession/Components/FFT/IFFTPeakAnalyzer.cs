using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTPeakAnalyzer : ISoundCaptureHandler
    {
        double[] SpectrumPeakData { get; }

        double DecayStep { get; set; }
    }
}
