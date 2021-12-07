namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTControl : IDrawable
    {
        IFFTViewModel ViewModel { get; set; }

        IFFTScaleDrawer FFTScaleDrawer { get; set; }

        bool ShowScaleLines { get; }
    }
}
