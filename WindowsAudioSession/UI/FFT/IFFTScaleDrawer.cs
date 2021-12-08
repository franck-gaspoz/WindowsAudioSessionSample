using System.Windows.Media;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTScaleDrawer
    {
        IFFTControl FFTControl { get; set; }

        Brush LineBrush { get; set; }

        double LineOpacity { get; set; }

        double Margin { get; set; }

    }
}
