using System.Windows;
using System.Windows.Media;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// fft control
    /// </summary>
    public interface IFFTControl : IDrawable
    {
        /// <summary>
        /// view model
        /// </summary>
        IFFTViewModel ViewModel { get; set; }

        /// <summary>
        /// scale drawer
        /// </summary>
        IFFTScaleDrawer FFTScaleDrawer { get; set; }

        /// <summary>
        /// background
        /// </summary>
        Brush DrawBackground { get; set; }

        /// <summary>
        /// indicates if bar count control should be visible or not
        /// </summary>
        bool IsBarCountControlVisible { get; set; }

        /// <summary>
        /// bar count
        /// </summary>
        int BarCount { get; set; }

        /// <summary>
        /// bar width percent
        /// </summary>
        int BarWidthPercent { get; set; }

        /// <summary>
        /// fft draw margin
        /// </summary>
        Thickness FFTDrawMargin { get; set; }

        /// <summary>
        /// indicates if scale lines should be drawn or not
        /// </summary>
        bool ShowScaleLines { get; }
    }
}
