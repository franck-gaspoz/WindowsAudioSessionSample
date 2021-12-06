
using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public class FFTProvider : IFFTProvider, ISoundCaptureHandler
    {
        public float[] FFT { get; protected set; }

        public FFTLength FFTLength { get; protected set; }

        public int AvailableLength { get; protected set; }

        public bool IsFFTAvailable { get; protected set; } = true;

        public FFTProvider(FFTLength fftLength)
        {
            FFTLength = fftLength;
            FFT = new float[fftLength.ToBufferSize()];
        }

        public void HandleTick()
        {
            AvailableLength = BassWasapi.BASS_WASAPI_GetData(
                FFT,
                (int)FFTLength.ToBassData());
            IsFFTAvailable = AvailableLength != -1;
        }

        public void Start() { }

        public void Stop()
        {
            IsFFTAvailable = false;
            AvailableLength = 0;
        }
    }
}
