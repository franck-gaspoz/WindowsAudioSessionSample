using System.Windows;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundWave
{
    public interface ISoundWaveViewModel : IModelBase
    {
        Thickness DrawMargin { get; set; }
    }
}
