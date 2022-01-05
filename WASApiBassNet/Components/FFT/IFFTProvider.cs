using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.FFT
{
    /// <summary>
    /// fft data provider
    /// </summary>
    public interface IFFTProvider : IAudioPlugin
    {
        /// <summary>
        /// fft data output
        /// </summary>
        float[] FFTData { get; }

        /// <summary>
        /// indicates if fft data is available
        /// </summary>
        bool IsFFTAvailable { get; }

        /// <summary>
        /// fft length
        /// </summary>
        FFTLength FFTLength { get; set; }

        /// <summary>
        /// indicates the real size of available fft data output
        /// </summary>
        int AvailableLength { get; }
    }
}
