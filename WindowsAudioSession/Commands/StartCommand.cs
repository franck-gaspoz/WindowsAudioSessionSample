using System;

using WindowsAudioSession.UI;

namespace WindowsAudioSession.Commands
{
    public class StartCommand : AbstractCommand
    {
        public override bool CanExecute(object parameter)
            => App.WASMainViewModel != null && App.WASMainViewModel.CanStart;

        public override void Execute(object parameter)
        {
            try
            {
                var components = App.WASComponents;
                var viewModel = App.WASMainViewModel;

                components.BuildComponents(viewModel);

                var deviceId = Convert.ToInt32(viewModel.SelectedDevice.id);

                components.AudioPlugEngine.Start(deviceId, viewModel.SampleFrequency);

                App.WASMainViewModel.IsStarted = true;

            }
            catch (Exception ex)
            {
                UIHelper.ShowError(ex);
            }
        }
    }
}
