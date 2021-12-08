using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTProvider : IAudioPlugHandler
    {
        float[] FFTData { get; }

        bool IsFFTAvailable { get; }

        FFTLength FFTLength { get; set; }

        int AvailableLength { get; }
    }
}
