
using WindowsAudioSession.Components;
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterStereoViewModel : ModelBase, ISoundCaptureHandler
    {
        public VuMeterViewModel VuMeterLeftViewModel { get; protected set; }
            = new VuMeterViewModel() { Label = "L" };

        public VuMeterViewModel VuMeterRightViewModel { get; protected set; }
            = new VuMeterViewModel() { Label = "R" };

        ISoundLevelCapture _soundLevelCapture;

        public VuMeterStereoViewModel() { }

        public void AttachTo(ISoundLevelCapture soundLevelCapture)
        {
            _soundLevelCapture = soundLevelCapture;
        }

        public void HandleTick()
        {
            VuMeterLeftViewModel.Level = _soundLevelCapture.LevelLeft / 20000d;
            VuMeterRightViewModel.Level = _soundLevelCapture.LevelRight / 20000d;
        }

        public void Start() { }

        public void Stop()
        {
            VuMeterLeftViewModel.Level = 0;
            VuMeterRightViewModel.Level = 0;
        }
    }
}
