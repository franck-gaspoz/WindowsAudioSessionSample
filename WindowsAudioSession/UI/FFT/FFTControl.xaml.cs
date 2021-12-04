using System.Windows;
using System.Windows.Controls;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// Logique d'interaction pour FFTControl.xaml
    /// </summary>
    public partial class FFTControl : UserControl
    {
        public FFTControlViewModel ViewModel { get; protected set; }

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
            set {
                SetValue(BarWidthPercentProperty, value);
                ViewModel.BarWidthPercent = value;
            }
        }

        public static readonly DependencyProperty BarWidthPercentProperty =
            DependencyProperty.Register("BarWidthPercent", typeof(int), typeof(FFTControl), new PropertyMetadata(100));

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
            ViewModel = new FFTControlViewModel(this);
            DataContext = ViewModel;
            Loaded += FFTControl_Loaded;
        }

        private void FFTControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.BarCount = BarCount;
            ViewModel.BarWidthPercent = BarWidthPercent;
        }
    }
}
