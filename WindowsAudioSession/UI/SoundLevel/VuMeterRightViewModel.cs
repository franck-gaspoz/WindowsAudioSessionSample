
using WASApiBassNet.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vumeter right channel view model
    /// </summary>
    public class VuMeterRightViewModel : AbstractVuMeterViewModel, IModelBase, IVuMeterViewModel, IAudioPlugin
    {
        /// <summary>
        /// creates a new instance
        /// </summary>
        public VuMeterRightViewModel()
        {
            _label = "R";
        }

        /// <inheritdoc/>
        public override void HandleTick()
            => Level = SoundLevelCapture.LevelRight * LevelScaleFactor;

    }
}