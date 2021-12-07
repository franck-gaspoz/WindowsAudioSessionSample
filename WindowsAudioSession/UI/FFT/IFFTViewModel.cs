
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTViewModel
    {
        int BarCount { get; set; }

        int BarWidthPercent { get; set; }        
        
    }
}
