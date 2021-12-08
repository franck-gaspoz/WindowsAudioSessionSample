
using WindowsAudioSession.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterRightViewModel : AbstractVuMeterViewModel, IModelBase, IVuMeterViewModel, IAudioPlugHandler
    {
        public VuMeterRightViewModel()
        {
            _label = "R";
        }

        public override void HandleTick()
            => Level = SoundLevelCapture.LevelRight * LevelScaleFactor;

    }
}