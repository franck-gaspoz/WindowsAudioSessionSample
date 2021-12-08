
using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterStereoViewModel : ModelBase, IModelBase, IVuMeterStereoViewModel
    {
        public IVuMeterViewModel VuMeterLeftViewModel { get; protected set; }
            = new VuMeterLeftViewModel() { Label = "L" };

        public IVuMeterViewModel VuMeterRightViewModel { get; protected set; }
            = new VuMeterRightViewModel() { Label = "R" };
    }
}
