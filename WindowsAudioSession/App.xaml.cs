using System;
using System.Globalization;
using System.Windows;

using WindowsAudioSession.UI;

namespace WindowsAudioSession
{
    /// <summary>
    /// App
    /// </summary>
    public partial class App : Application
    {
        public static WASMainWindow WASMainWindow { get; set; }

        public static WASMainViewModel WASMainViewModel { get; set; }

        public static WASComponents WASComponents { get; set; }

        public App()
        {
            try
            {
                CultureInfo.DefaultThreadCurrentCulture =
                CultureInfo.DefaultThreadCurrentUICulture =
                    new CultureInfo("en");

                WASMainViewModel = new WASMainViewModel();
                WASMainWindow = new WASMainWindow
                {
                    DataContext = WASMainViewModel
                };

                WASComponents = new WASComponents();

                _ = WASMainWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                UIHelper.ShowError(ex);
                Environment.Exit(1);
            }
        }
    }
}
