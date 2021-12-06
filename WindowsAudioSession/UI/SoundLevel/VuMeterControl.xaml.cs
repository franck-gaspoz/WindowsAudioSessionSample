using System.Windows.Controls;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vu-meter control
    /// </summary>
    public partial class VuMeterControl : UserControl
    {
        public IVuMeterViewModel ViewModel { get; protected set; }

        public VuMeterControl()
        {
            InitializeComponent();
            ViewModel = new VuMeterLeftViewModel();
            DataContext = ViewModel;
        }
    }
}
