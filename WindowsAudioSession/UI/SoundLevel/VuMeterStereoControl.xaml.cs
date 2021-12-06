using System.Windows.Controls;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// Logique d'interaction pour VuMeterStereoControl.xaml
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
