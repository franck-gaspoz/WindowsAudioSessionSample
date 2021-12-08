using System.Windows.Controls;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vu-meter control
    /// </summary>
    public partial class VuMeterControl : UserControl, IVuMeterControl
    {
        IVuMeterViewModel _viewModel;
        public IVuMeterViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        public VuMeterControl()
        {
            InitializeComponent();
        }
    }
}
