using System.Windows.Media;

namespace WindowsAudioSession.UI.SoundWave
{
    /// <summary>
    /// sound wave control
    /// </summary>
    public interface ISoundWaveControl : IDrawable
    {
        /// <summary>
        /// sound wave view model
        /// </summary>
        ISoundWaveViewModel ViewModel { get; set; }

        /// <summary>
        /// draw background
        /// </summary>
        Brush DrawBackground { get; set; }
    }
}
