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
        /// <inheritdoc/>
        public ISoundWaveViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = ViewModel;
                DataContext = _viewModel;
            }
        }

        /// <inheritdoc/>
        public Brush DrawBackground
        {
            get => (Brush)GetValue(DrawBackgroundProperty);
            set => SetValue(DrawBackgroundProperty, value);
        }

        /// <summary>
        /// brush dependency property
        /// </summary>
        public static readonly DependencyProperty DrawBackgroundProperty =
            DependencyProperty.Register("DrawBackground", typeof(Brush), typeof(SoundWaveControl), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// creates a new instance
        /// </summary>
        public SoundWaveControl()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        public Canvas GetDrawingSurface() => WaveGraph;
    }
}
