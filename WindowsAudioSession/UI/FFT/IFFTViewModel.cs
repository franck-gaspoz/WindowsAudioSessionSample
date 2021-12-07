
using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTViewModel : ISoundCaptureHandler
    {
        int BarCount { get; set; }

        int BarWidthPercent { get; set; }

    }
}
