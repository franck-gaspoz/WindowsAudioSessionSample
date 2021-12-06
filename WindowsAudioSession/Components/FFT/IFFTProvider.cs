namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTProvider
    {
        float[] FFT { get; }

        bool IsFFTAvailable { get; }

        FFTLength FFTLength { get; }
    }
}
