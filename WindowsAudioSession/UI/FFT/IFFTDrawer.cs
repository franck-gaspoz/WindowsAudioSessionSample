using System.Windows.Media;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTDrawer : ISoundCaptureHandler
    {
        IFFTAnalyzer FFTAnalyser { get; }

        double Margin { get; set; }

        double WidthPercent { get; set; }

        Brush BarBrush { get; set; }

        bool IsStarted { get; }

        void AttachTo(IFFTAnalyzer fftAnalyzer);
    }
}
