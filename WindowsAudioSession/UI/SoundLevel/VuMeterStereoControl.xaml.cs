using System.Windows.Controls;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vu-meter stereo control
    /// </summary>
    public partial class VuMeterStereoControl : UserControl
    {
        public IVuMeterStereoViewModel ViewModel { get; protected set; }

        public VuMeterStereoControl()
        {
            InitializeComponent();
            ViewModel = new VuMeterStereoViewModel();
            DataContext = ViewModel;
        }
    }
}
