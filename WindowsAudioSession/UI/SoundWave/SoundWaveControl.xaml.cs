using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WindowsAudioSession.UI.SoundWave
{
    /// <summary>
    /// sound wave control
    /// </summary>
    public partial class SoundWaveControl : UserControl, ISoundWaveControl, IDrawable
    {
        ISoundWaveViewModel _viewModel;
        public ISoundWaveViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = ViewModel;
                DataContext = _viewModel;
            }
        }

        public Brush DrawBackground
        {
            get => (Brush)GetValue(DrawBackgroundProperty);
            set => SetValue(DrawBackgroundProperty, value);
        }

        public static readonly DependencyProperty DrawBackgroundProperty =
            DependencyProperty.Register("DrawBackground", typeof(Brush), typeof(SoundWaveControl), new PropertyMetadata(Brushes.Black));

        public SoundWaveControl()
        {
            InitializeComponent();
        }

        public Canvas GetDrawingSurface() => WaveGraph;
    }
}
