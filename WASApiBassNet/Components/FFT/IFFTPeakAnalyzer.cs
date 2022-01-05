using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.FFT
{
    /// <summary>
    /// fft peak analyzer
    /// </summary>
    public interface IFFTPeakAnalyzer : IAudioPlugin
    {
        /// <summary>
        /// fft analyzer
        /// </summary>
        IFFTAnalyzer FFTAnalyzer { get; set; }

        /// <summary>
        /// spectrum peak data output
        /// </summary>
        double[] SpectrumPeakData { get; }

        /// <summary>
        /// peak decay step
        /// </summary>
        double DecayStep { get; set; }

        /// <summary>
        /// bars count
        /// </summary>
        int BarsCount { get; set; }
    }
}
