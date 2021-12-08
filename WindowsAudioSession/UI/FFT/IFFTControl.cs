using System.Windows;
using System.Windows.Media;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTControl : IDrawable
    {
        IFFTViewModel ViewModel { get; set; }

        IFFTScaleDrawer FFTScaleDrawer { get; set; }

        Brush DrawBackground { get; set; }

        bool IsBarCountControlVisible { get; set; }

        int BarCount { get; set; }

        int BarWidthPercent { get; set; }

        Thickness FFTDrawMargin { get; set; }

        bool ShowScaleLines { get; }
    }
}
