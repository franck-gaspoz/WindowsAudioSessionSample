using System.Windows.Media;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// fft scale drawer
    /// </summary>
    public interface IFFTScaleDrawer
    {
        /// <summary>
        /// fft control
        /// </summary>
        IFFTControl FFTControl { get; set; }

        /// <summary>
        /// line brush
        /// </summary>
        Brush LineBrush { get; set; }

        /// <summary>
        /// line opacity
        /// </summary>
        double LineOpacity { get; set; }

        /// <summary>
        /// margin
        /// </summary>
        double Margin { get; set; }

    }
}
