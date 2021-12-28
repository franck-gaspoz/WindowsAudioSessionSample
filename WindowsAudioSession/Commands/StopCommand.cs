namespace WindowsAudioSession.Commands
{
    public class StopCommand : AbstractCommand
    {
        public override bool CanExecute(object parameter)
            => App.WASMainViewModel != null && App.WASMainViewModel.IsStarted;

        /// <summary>
        /// stops audio engine, update app state
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            App.AppComponents.AudioPlugEngine.Stop();

            App.WASMainViewModel.IsStarted = false;
            App.WASMainViewModel.CanStart = true;
        }
    }
}
