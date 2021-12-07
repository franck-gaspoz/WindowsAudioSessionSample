
using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTViewModel : IAudioPlugHandler
    {
        int BarCount { get; set; }

        int BarWidthPercent { get; set; }

    }
}
