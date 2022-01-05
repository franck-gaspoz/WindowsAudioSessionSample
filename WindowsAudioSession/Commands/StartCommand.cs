using System;

using WindowsAudioSession.UI;

namespace WindowsAudioSession.Commands
{
    /// <summary>
    /// build and setup app components, starts audio engine, update app state
    /// </summary>
    public class StartCommand : AbstractCommand<StartCommand>
    {
        ///<inheritdoc/>
        public override bool CanExecute(object parameter)
            => App.WASMainViewModel != null && App.WASMainViewModel.CanStart;

        ///<inheritdoc/>
        public override void Execute(object parameter)
        {
            try
            {
                var components = App.AppComponents;
                var viewModel = App.WASMainViewModel;

                components.BuildComponents(viewModel);

                var deviceId = Convert.ToInt32(viewModel.SelectedDevice.id);

                components.AudioPluginEngine.Start(deviceId, viewModel.SampleFrequency);

                App.WASMainViewModel.IsStarted = true;

            }
            catch (Exception ex)
            {
                UIHelper.ShowError(ex);
            }
        }
    }
}
