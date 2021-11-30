namespace WindowsAudioSession.Commands
{
    public class StopCommand : AbstractCommand
    {
        public override bool CanExecute(object parameter)
            => App.WASOverviewWindowViewModel != null && App.WASOverviewWindowViewModel.IsStarted;

        public override void Execute(object parameter)
        {
            App.WASComponents.SoundListener.Stop();

            App.WASOverviewWindowViewModel.IsStarted = false;
            App.WASOverviewWindowViewModel.CanStart = true;
        }
    }
}
