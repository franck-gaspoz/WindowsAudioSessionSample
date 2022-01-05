
using Un4seen.BassWasapi;

using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.FFT
{
    /// <summary>
    /// fft data provider
    /// </summary>
    public class FFTProvider : IFFTProvider, IAudioPlugin
    {
        /// <inheritdoc/>
        public float[] FFTData { get; protected set; }

        FFTLength _fftLength;
        /// <inheritdoc/>
        public FFTLength FFTLength
        {
            get => _fftLength;
            set
            {
                _fftLength = value;
                FFTData = new float[_fftLength.ToBufferSize()];
            }
        }

        /// <inheritdoc/>
        public int AvailableLength { get; protected set; }

        /// <inheritdoc/>
        public bool IsFFTAvailable { get; protected set; } = true;

        /// <inheritdoc/>
        public void HandleTick()
        {
            AvailableLength = BassWasapi.BASS_WASAPI_GetData(
                FFTData,
                (int)FFTLength.ToBassData());
            IsFFTAvailable = AvailableLength != -1;
        }

        /// <inheritdoc/>
        public void Start() { }

        /// <inheritdoc/>
        public void Stop()
        {
            IsFFTAvailable = false;
            AvailableLength = 0;
        }
    }
}
