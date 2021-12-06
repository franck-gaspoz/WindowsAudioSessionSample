using System;
using System.Globalization;
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

        public static WASMainViewModel WASOverviewWindowViewModel { get; set; }

        public static WASComponents WASComponents { get; set; }

        public App()
        {
            try
            {
                CultureInfo.DefaultThreadCurrentCulture =
                CultureInfo.DefaultThreadCurrentUICulture =
                    new CultureInfo("en");

                WASOverviewWindowViewModel = new WASMainViewModel();
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
