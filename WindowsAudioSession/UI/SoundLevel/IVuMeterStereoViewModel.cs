
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public interface IVuMeterStereoViewModel : ISoundCaptureHandler
    {
        IVuMeterViewModel VuMeterLeftViewModel { get; }

        IVuMeterViewModel VuMeterRightViewModel { get; }

        ISoundLevelCapture SoundLevelCapture { get; }

        void AttachTo(ISoundLevelCapture soundLevelCapture);
    }
}
