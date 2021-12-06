using System.Windows.Media;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTScaleDrawer
    {
        FFTControl FFTControl { get; }

        Brush LineBrush { get; set; }

        double LineOpacity { get; set; }

    }
}
