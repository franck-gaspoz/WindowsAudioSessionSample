using System.Windows;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundWave
{
    /// <summary>
    /// sound wave view model
    /// </summary>
    public interface ISoundWaveViewModel : IModelBase
    {
        /// <summary>
        /// draw margin
        /// </summary>
        Thickness DrawMargin { get; set; }
    }
}
