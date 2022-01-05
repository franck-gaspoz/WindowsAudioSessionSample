using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.FFT
{
    /// <summary>
    /// fft analyzer
    /// </summary>
    public interface IFFTAnalyzer : IAudioPlugin
    {
        /// <summary>
        /// fft provider
        /// </summary>
        IFFTProvider FFTProvider { get; set; }

        /// <summary>
        /// output spectrum data
        /// </summary>
        double[] SpectrumData { get; }

        /// <summary>
        /// bars count
        /// </summary>
        int BarsCount { get; set; }
    }
}
