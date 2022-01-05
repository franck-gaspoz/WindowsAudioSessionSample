
using WASApiBassNet.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vumeter left channel view model
    /// </summary>
    public class VuMeterLeftViewModel : AbstractVuMeterViewModel, IModelBase, IVuMeterViewModel, IAudioPlugin
    {
        /// <summary>
        /// creates a new instance
        /// </summary>
        public VuMeterLeftViewModel()
        {
            _label = "L";
        }

        /// <inheritdoc/>
        public override void HandleTick()
            => Level = SoundLevelCapture.LevelLeft * LevelScaleFactor;
    }
}