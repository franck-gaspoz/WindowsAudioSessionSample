
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public interface IVuMeterStereoViewModel
    {
        IVuMeterViewModel VuMeterLeftViewModel { get; }

        IVuMeterViewModel VuMeterRightViewModel { get; }

    }
}
