using System.Windows.Media;

using WASApiBassNet.Components.AudioCapture;
using WASApiBassNet.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// fft drawer
    /// </summary>
    public interface IFFTDrawer : IAudioPlugin
    {
        /// <summary>
        /// fft analyzer
        /// </summary>
        IFFTAnalyzer FFTAnalyser { get; set; }

        /// <summary>
        /// drawable control
        /// </summary>
        IDrawable Drawable { get; set; }

        /// <summary>
        /// margin
        /// </summary>
        double Margin { get; set; }

        /// <summary>
        /// bar width percent
        /// </summary>
        double BarWidthPercent { get; set; }

        /// <summary>
        /// bar brush
        /// </summary>
        Brush BarBrush { get; set; }

        /// <summary>
        /// indicates if drawer is started or not
        /// </summary>
        bool IsStarted { get; }
    }
}
