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
        /// <inheritdoc/>
        public IFFTViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        /// <inheritdoc/>
        public IFFTScaleDrawer FFTScaleDrawer { get; set; }

        /// <summary>
        /// draw background 
        /// </summary>
        public Brush DrawBackground
        {
            get => (Brush)GetValue(DrawBackgroundProperty);
            set => SetValue(DrawBackgroundProperty, value);
        }

        /// <summary>
        /// draw background dependency property
        /// </summary>
        public static readonly DependencyProperty DrawBackgroundProperty =
            DependencyProperty.Register("DrawBackground", typeof(Brush), typeof(FFTControl), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// is bar count control visible
        /// </summary>
        public bool IsBarCountControlVisible
        {
            get => (bool)GetValue(IsBarCountControlVisibleProperty);
            set => SetValue(IsBarCountControlVisibleProperty, value);
        }

        /// <summary>
        /// is bar count control visible dependency property
        /// </summary>
        public static readonly DependencyProperty IsBarCountControlVisibleProperty =
            DependencyProperty.Register("IsBarCountControlVisible", typeof(bool), typeof(FFTControl), new PropertyMetadata(true));

        /// <summary>
        /// is bar size control visible
        /// </summary>
        public bool IsBarSizeControlVisible
        {
            get => (bool)GetValue(IsBarSizeControlVisibleProperty);
            set => SetValue(IsBarSizeControlVisibleProperty, value);
        }

        /// <summary>
        /// is bar size control visible dependency property
        /// </summary>
        public static readonly DependencyProperty IsBarSizeControlVisibleProperty =
            DependencyProperty.Register("IsBarSizeControlVisible", typeof(bool), typeof(FFTControl), new PropertyMetadata(true));

        /// <inheritdoc/>
        public int BarCount
        {
            get => (int)GetValue(BarCountProperty);
            set
            {
                SetValue(BarCountProperty, value);
                ViewModel.BarCount = value;
            }
        }

        /// <summary>
        /// bar count dependency property
        /// </summary>
        public static readonly DependencyProperty BarCountProperty =
            DependencyProperty.Register("BarCount", typeof(int), typeof(FFTControl), new PropertyMetadata(512));

        /// <inheritdoc/>
        public int BarWidthPercent
        {
            get => (int)GetValue(BarWidthPercentProperty);
            set
            {
                SetValue(BarWidthPercentProperty, value);
                ViewModel.BarWidthPercent = value;
            }
        }

        /// <summary>
        /// bar width percent dependency property
        /// </summary>
        public static readonly DependencyProperty BarWidthPercentProperty =
            DependencyProperty.Register("BarWidthPercent", typeof(int), typeof(FFTControl), new PropertyMetadata(100));

        /// <inheritdoc/>
        public bool ShowScaleLines
        {
            get { return (bool)GetValue(ShowScaleLinesProperty); }
            set { SetValue(ShowScaleLinesProperty, value); }
        }

        /// <summary>
        /// show scale line dependency property
        /// </summary>
        public static readonly DependencyProperty ShowScaleLinesProperty =
            DependencyProperty.Register("ShowScaleLines", typeof(bool), typeof(FFTControl), new PropertyMetadata(false));

        /// <inheritdoc/>
        public Thickness FFTDrawMargin
        {
            get => (Thickness)GetValue(FFTDrawMarginProperty);
            set => SetValue(FFTDrawMarginProperty, value);
        }

        /// <summary>
        /// fft draw margin dependency property
        /// </summary>
        public static readonly DependencyProperty FFTDrawMarginProperty =
            DependencyProperty.Register("FFTDrawMargin", typeof(Thickness), typeof(FFTControl), new PropertyMetadata(new Thickness(8)));

        /// <summary>
        /// creates a new control
        /// </summary>
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

        /// <inheritdoc/>
        public Canvas GetDrawingSurface()
            => BarGraph;
    }
}
