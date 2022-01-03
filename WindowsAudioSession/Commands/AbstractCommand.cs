using System;
using System.Windows.Input;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.Commands
{
    /// <summary>
    /// abstract command
    /// </summary>
    public abstract class AbstractCommand<ConcreteType> :
        Singleton<ConcreteType>, ICommand
        where ConcreteType : class, ICommand, new()
    {
        /// <summary>
        /// default can execute changed event handler
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// can execute
        /// </summary>
        /// <param name="parameter">parameter</param>
        /// <returns>true if can execute, false otherwize</returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// execute command
        /// </summary>
        /// <param name="parameter">parameter</param>
        public abstract void Execute(object parameter);
    }
}