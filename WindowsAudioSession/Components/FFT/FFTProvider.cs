
using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public class FFTProvider : IFFTProvider, IAudioPlugHandler
    {
        public float[] FFTData { get; protected set; }

        FFTLength _fftLength;
        public FFTLength FFTLength
        {
            get => _fftLength;
            set
            {
                _fftLength = value;
                FFTData = new float[_fftLength.ToBufferSize()];
            }
        }

        public int AvailableLength { get; protected set; }

        public bool IsFFTAvailable { get; protected set; } = true;

        public void HandleTick()
        {
            AvailableLength = BassWasapi.BASS_WASAPI_GetData(
                FFTData,
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
