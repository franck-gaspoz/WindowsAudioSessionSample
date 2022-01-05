
using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vumeter stereo view model
    /// </summary>
    public class VuMeterStereoViewModel : ModelBase, IModelBase, IVuMeterStereoViewModel
    {
        /// <summary>
        /// vumeter left channel view model
        /// </summary>
        public IVuMeterViewModel VuMeterLeftViewModel { get; protected set; }
            = new VuMeterLeftViewModel() { Label = "L" };

        /// <summary>
        /// vumeter right channel view model
        /// </summary>
        public IVuMeterViewModel VuMeterRightViewModel { get; protected set; }
            = new VuMeterRightViewModel() { Label = "R" };
    }
}
