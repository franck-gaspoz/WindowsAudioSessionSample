using System.Windows;

namespace WindowsAudioSession.UI
{
    /// <summary>
    /// Logique d'interaction pour WASOverviewWindow.xaml
    /// </summary>
    public partial class WASOverviewWindow : Window
    {
        public WASOverviewWindowViewModel ViewModel { get; set; }

        public WASOverviewWindow()
        {
            InitializeComponent();

            ViewModel = new WASOverviewWindowViewModel(BarGraph);
            DataContext = ViewModel;
        }

        void BTStart_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Start();
        }

        void BTStop_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Stop();
        }
    }
}
