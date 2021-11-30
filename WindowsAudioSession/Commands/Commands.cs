using System.Windows.Input;

namespace WindowsAudioSession.Commands
{
    public static class Commands
    {
        public static ICommand Start { get; } = new StartCommand();

        public static ICommand Stop { get; } = new StopCommand();
    }
}
