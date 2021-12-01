using System;
using System.Windows;

using WindowsAudioSession.UI;

namespace WindowsAudioSession
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static WASOverviewWindow WASOverviewWindow { get; set; }

        public static WASOverviewWindowViewModel WASOverviewWindowViewModel { get; set; }

        public static WASComponents WASComponents { get; set; }

        public App()
        {
            try
            {
                WASOverviewWindowViewModel = new WASOverviewWindowViewModel();
                WASOverviewWindow = new WASOverviewWindow
                {
                    DataContext = WASOverviewWindowViewModel
                };

                WASComponents = new WASComponents();

                _ = WASOverviewWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                UIHelper.ShowError(ex);
                Environment.Exit(1);
            }
        }
    }
}
