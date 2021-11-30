using System;
using System.Windows.Input;

namespace WindowsAudioSession.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
