using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public interface IVuMeterViewModel : IAudioPlugHandler
    {
        double LevelScaleFactor { get; set; }

        ISoundLevelCapture SoundLevelCapture { get; set; }

        double Level { get; set; }

        double InvertedLevel { get; set; }

        string Label { get; set; }

        double LabelWidth { get; set; }
    }
}
