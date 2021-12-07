using System.Windows.Media;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTPeakDrawer : ISoundCaptureHandler
    {
        IFFTPeakAnalyzer FFTPeakAnalyser { get; set; }

        IDrawable Drawable { get; set; }

        double Margin { get; set; }

        double WidthPercent { get; set; }

        double PeakBarHeight { get; set; }

        Brush BarBrush { get; set; }

        bool IsStarted { get; }
    }
}
