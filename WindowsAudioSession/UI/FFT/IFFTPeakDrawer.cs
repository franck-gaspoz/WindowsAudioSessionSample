using System.Windows.Media;

using WASApiBassNet.Components.AudioCapture;
using WASApiBassNet.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTPeakDrawer : IAudioPlugin
    {
        /// <summary>
        /// fft peak analyzer
        /// </summary>
        IFFTPeakAnalyzer FFTPeakAnalyser { get; set; }

        /// <summary>
        /// drawable control
        /// </summary>
        IDrawable Drawable { get; set; }

        /// <summary>
        /// margin
        /// </summary>
        double Margin { get; set; }

        /// <summary>
        /// width percent
        /// </summary>
        double WidthPercent { get; set; }

        /// <summary>
        /// pick bar height
        /// </summary>
        double PeakBarHeight { get; set; }

        /// <summary>
        /// bar brush
        /// </summary>
        Brush BarBrush { get; set; }

        /// <summary>
        /// indicates if the drawer is started or not
        /// </summary>
        bool IsStarted { get; }
    }
}
