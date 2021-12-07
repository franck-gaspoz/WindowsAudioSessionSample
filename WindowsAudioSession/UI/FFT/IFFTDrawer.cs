using System.Windows.Media;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTDrawer : ISoundCaptureHandler
    {
        IFFTAnalyzer FFTAnalyser { get; set; }

        IDrawable Drawable { get; set; }

        double Margin { get; set; }

        double BarWidthPercent { get; set; }

        Brush BarBrush { get; set; }

        bool IsStarted { get; }
    }
}
