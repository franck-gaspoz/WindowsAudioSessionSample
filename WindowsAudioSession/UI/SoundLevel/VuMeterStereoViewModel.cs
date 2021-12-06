using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterStereoViewModel : ModelBase,
        IVuMeterStereoViewModel, ISoundCaptureHandler
    {
        public IVuMeterViewModel VuMeterLeftViewModel { get; protected set; }
            = new VuMeterViewModel() { Label = "L" };

        public IVuMeterViewModel VuMeterRightViewModel { get; protected set; }
            = new VuMeterViewModel() { Label = "R" };

        public ISoundLevelCapture SoundLevelCapture { get; protected set; }

        public VuMeterStereoViewModel() { }

        public void AttachTo(ISoundLevelCapture soundLevelCapture)
        {
            SoundLevelCapture = soundLevelCapture;
        }

        public void HandleTick()
        {
            VuMeterLeftViewModel.Level = SoundLevelCapture.LevelLeft / 20000d;
            VuMeterRightViewModel.Level = SoundLevelCapture.LevelRight / 20000d;
        }

        public void Start() { }

        public void Stop()
        {
            VuMeterLeftViewModel.Level = 0;
            VuMeterRightViewModel.Level = 0;
        }
    }
}
