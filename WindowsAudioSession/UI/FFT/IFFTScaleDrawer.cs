using System.Windows.Media;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTScaleDrawer
    {
        Brush LineBrush { get; set; }

        double LineOpacity { get; set; }

    }
}
