using System.Windows.Controls;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// Logique d'interaction pour FFTControl.xaml
    /// </summary>
    public partial class FFTControl : UserControl
    {
        public FFTControlViewModel ViewModel { get; protected set; }

        public FFTControl()
        {
            InitializeComponent();
            ViewModel = new FFTControlViewModel(this);
        }
    }
}
