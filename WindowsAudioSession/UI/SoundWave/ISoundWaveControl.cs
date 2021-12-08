using System.Windows.Media;

namespace WindowsAudioSession.UI.SoundWave
{
    public interface ISoundWaveControl : IDrawable
    {
        ISoundWaveViewModel ViewModel { get; set; }

        Brush DrawBackground { get; set; }
    }
}
