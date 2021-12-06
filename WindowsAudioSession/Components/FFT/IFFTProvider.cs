using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTProvider : ISoundCaptureHandler
    {
        float[] FFT { get; }

        bool IsFFTAvailable { get; }

        FFTLength FFTLength { get; }
    }
}
