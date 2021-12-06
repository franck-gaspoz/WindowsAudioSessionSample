using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public interface IVuMeterViewModel : ISoundCaptureHandler
    {
        ISoundLevelCapture SoundLevelCapture { get; }

        void AttachTo(ISoundLevelCapture soundLevelCapture);

        double Level { get; set; }

        double InvertedLevel { get; set; }

        string Label { get; set; }

        double LabelWidth { get; set; }
    }
}
