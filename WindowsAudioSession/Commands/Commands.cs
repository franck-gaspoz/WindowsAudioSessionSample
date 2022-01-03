using System.Windows.Input;

namespace WindowsAudioSession.Commands
{
    /// <summary>
    /// commands
    /// </summary>
    public static class Commands
    {
        /// <summary>
        /// start autio engine
        /// </summary>
        public static ICommand Start => StartCommand.Instance;

        /// <summary>
        /// stop audio engine
        /// </summary>
        public static ICommand Stop => StopCommand.Instance;
    }
}
