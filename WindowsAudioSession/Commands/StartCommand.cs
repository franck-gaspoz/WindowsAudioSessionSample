using System;

using WindowsAudioSession.UI;

namespace WindowsAudioSession.Commands
{
    public class StartCommand : AbstractCommand
    {
        public override bool CanExecute(object parameter)
            => App.WASOverviewWindowViewModel != null && App.WASOverviewWindowViewModel.CanStart;

        public override void Execute(object parameter)
        {
            try
            {
                var components = App.WASComponents;
                var viewModel = App.WASOverviewWindowViewModel;

                components.BuildComponents(viewModel);

                var deviceId = Convert.ToInt32(viewModel.SelectedDevice.id);

                components.SoundListener.Start(deviceId, viewModel.SampleFrequency);

                App.WASOverviewWindowViewModel.IsStarted = true;

            }
            catch (Exception ex)
            {
                UIHelper.ShowError(ex);
            }
        }
    }
}
