using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterStereoViewModel : ModelBase,  IVuMeterStereoViewModel
    { 
        public IVuMeterViewModel VuMeterLeftViewModel { get; protected set; }
            = new VuMeterLeftViewModel() { Label = "L" };

        public IVuMeterViewModel VuMeterRightViewModel { get; protected set; }
            = new VuMeterRightViewModel() { Label = "R" };      
    }
}
