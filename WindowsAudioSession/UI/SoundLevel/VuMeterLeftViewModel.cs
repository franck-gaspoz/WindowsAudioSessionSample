
using WindowsAudioSession.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterLeftViewModel : AbstractVuMeterViewModel, IModelBase, IVuMeterViewModel, IAudioPlugHandler
    {
        public VuMeterLeftViewModel()
        {
            _label = "L";
        }

        public override void HandleTick()
            => Level = SoundLevelCapture.LevelLeft * LevelScaleFactor;
    }
}