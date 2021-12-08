using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// fft control
    /// </summary>
    public partial class FFTControl : UserControl, IFFTControl, IDrawable
    {
        IFFTViewModel _viewModel;
        public IFFTViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        public IFFTScaleDrawer FFTScaleDrawer { get; set; }

        public Brush DrawBackground
        {
            get => (Brush)GetValue(DrawBackgroundProperty);
            set => SetValue(DrawBackgroundProperty, value);
        }

        public static readonly DependencyProperty DrawBackgroundProperty =
            DependencyProperty.Register("DrawBackground", typeof(Brush), typeof(FFTControl), new PropertyMetadata(Brushes.Black));

        public bool IsBarCountControlVisible
        {
            get => (bool)GetValue(IsBarCountControlVisibleProperty);
            set => SetValue(IsBarCountControlVisibleProperty, value);
        }

        public static readonly DependencyProperty IsBarCountControlVisibleProperty =
            DependencyProperty.Register("IsBarCountControlVisible", typeof(bool), typeof(FFTControl), new PropertyMetadata(true));

        public bool IsBarSizeControlVisible
        {
            get => (bool)GetValue(IsBarSizeControlVisibleProperty);
            set => SetValue(IsBarSizeControlVisibleProperty, value);
        }

        public static readonly DependencyProperty IsBarSizeControlVisibleProperty =
            DependencyProperty.Register("IsBarSizeControlVisible", typeof(bool), typeof(FFTControl), new PropertyMetadata(true));

        public int BarCount
        {
            get => (int)GetValue(BarCountProperty);
            set
            {
                SetValue(BarCountProperty, value);
                ViewModel.BarCount = value;
            }
        }

        public static readonly DependencyProperty BarCountProperty =
            DependencyProperty.Register("BarCount", typeof(int), typeof(FFTControl), new PropertyMetadata(512));

        public int BarWidthPercent
        {
            get => (int)GetValue(BarWidthPercentProperty);
            set
            {
                SetValue(BarWidthPercentProperty, value);
                ViewModel.BarWidthPercent = value;
            }
        }

        public static readonly DependencyProperty BarWidthPercentProperty =
            DependencyProperty.Register("BarWidthPercent", typeof(int), typeof(FFTControl), new PropertyMetadata(100));

        public bool ShowScaleLines
        {
            get { return (bool)GetValue(ShowScaleLinesProperty); }
            set { SetValue(ShowScaleLinesProperty, value); }
        }

        public static readonly DependencyProperty ShowScaleLinesProperty =
            DependencyProperty.Register("ShowScaleLines", typeof(bool), typeof(FFTControl), new PropertyMetadata(false));

        public Thickness FFTDrawMargin
        {
            get => (Thickness)GetValue(FFTDrawMarginProperty);
            set => SetValue(FFTDrawMarginProperty, value);
        }

        public static readonly DependencyProperty FFTDrawMarginProperty =
            DependencyProperty.Register("FFTDrawMargin", typeof(Thickness), typeof(FFTControl), new PropertyMetadata(new Thickness(8)));

        public FFTControl()
        {
            InitializeComponent();
            FFTScaleDrawer = new FFTScaleDrawer
            {
                FFTControl = this
            };
            DataContextChanged += FFTControl_DataContextChanged;
        }

        private void FFTControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ViewModel == null) return;
            ViewModel.BarCount = BarCount;
            ViewModel.BarWidthPercent = BarWidthPercent;
        }

        public Canvas GetDrawingSurface()
            => BarGraph;
    }
}
