using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WindowsAudioSession.UI.SoundWave
{
    /// <summary>
    /// sound wave control
    /// </summary>
    public partial class SoundWaveControl : UserControl, IDrawable
    {
        public Brush DrawBackground
        {
            get => (Brush)GetValue(DrawBackgroundProperty);
            set => SetValue(DrawBackgroundProperty, value);
        }

        public static readonly DependencyProperty DrawBackgroundProperty =
            DependencyProperty.Register("DrawBackground", typeof(Brush), typeof(SoundWaveControl), new PropertyMetadata(Brushes.Black));

        public ISoundWaveViewModel ViewModel { get; protected set; }

        public SoundWaveControl()
        {
            InitializeComponent();
            ViewModel = new SoundWaveViewModel(this);
            DataContext = ViewModel;
        }

        public Canvas GetDrawingSurface() => WaveGraph;
    }
}
