namespace WindowsAudioSession.Commands
{
    /// <summary>
    /// stops audio engine, update app state
    /// </summary>
    public class StopCommand : AbstractCommand<StopCommand>
    {
        ///<inheritdoc/>
        public override bool CanExecute(object parameter)
            => App.WASMainViewModel != null && App.WASMainViewModel.IsStarted;

        ///<inheritdoc/>
        public override void Execute(object parameter)
        {
            App.AppComponents.AudioPluginEngine.Stop();

            App.WASMainViewModel.IsStarted = false;
            App.WASMainViewModel.CanStart = true;
        }
    }
}
