
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTViewModel : ISoundCaptureHandler
    {
        IFFTDrawer FFTDrawer { get; }

        int BarCount { get; set; }

        int BarWidthPercent { get; set; }

        bool IsStarted { get; }

        void AttachTo(IFFTAnalyzer fftAnalyzer);

    }
}
