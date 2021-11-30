using System;

using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession.Commands
{
    public class StartCommand : AbstractCommand
    {
        public override bool CanExecute(object parameter)
            => App.WASOverviewWindowViewModel != null && App.WASOverviewWindowViewModel.CanStart;

        public override void Execute(object parameter)
        {
            var components = App.WASComponents;

            components.BuildComponents(
                SampleLength.FFT1024,
                App.WASOverviewWindowViewModel.BarCount
                );

            var deviceId = Convert.ToInt32(App.WASOverviewWindowViewModel.SelectedDevice.id);

            components.SoundListener.Start(deviceId);

            App.WASOverviewWindowViewModel.IsStarted = true;
        }
    }
}
