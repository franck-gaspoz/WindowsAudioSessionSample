using System;
using System.Globalization;
using System.Windows;

using WindowsAudioSession.Commands;
using WindowsAudioSession.UI;

namespace WindowsAudioSession
{
    /// <summary>
    /// App - facade pattern that encapsulates the main components
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// main window view
        /// </summary>
        public static WASMainWindow WASMainWindow { get; set; }

        /// <summary>
        /// main window view model
        /// </summary>
        public static IWASMainViewModel WASMainViewModel { get; set; }

        /// <summary>
        /// application components
        /// </summary>
        public static IAppComponents AppComponents { get; set; }

        /// <summary>
        /// create instance of the application
        /// </summary>
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

                AppComponents = new AppComponents();
                AppComponents.AudioPluginEngine.DispatcherTimerEventHandlerError +=
                    (sender, eventArgs) =>
                    {
                        UIHelper.ShowError(eventArgs.Exception);
                        StopCommand.Instance.Execute(null);
                    };

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
