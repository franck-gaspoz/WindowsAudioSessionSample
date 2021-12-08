using System.Windows.Controls;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vu-meter stereo control
    /// </summary>
    public partial class VuMeterStereoControl : UserControl, IVuMeterStereoControl
    {
        IVuMeterStereoViewModel _viewModel;
        public IVuMeterStereoViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        public VuMeterStereoControl()
        {
            InitializeComponent();
        }
    }
}
