using System.Windows.Controls;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// Logique d'interaction pour VuMeterControl.xaml
    /// </summary>
    public partial class VuMeterControl : UserControl
    {
        public IVuMeterViewModel ViewModel { get; protected set; }

        public VuMeterControl()
        {
            InitializeComponent();
            ViewModel = new VuMeterViewModel();
            DataContext = ViewModel;
        }
    }
}
