using System;
using System.Collections.Generic;
using System.Windows;

namespace WindowsAudioSession.UI
{
    /// <summary>
    /// ui helpers methods
    /// </summary>
    public class UIHelper
    {
        /// <summary>
        /// show an error for an exception
        /// </summary>
        /// <param name="exception">exception</param>
        public static void ShowError(Exception exception)
        {
            var messages = new List<string>() { exception.Message };
            var innerException = exception;
            while ((innerException = innerException.InnerException) != null)
            {
                messages.Add(innerException.Message);
            }
            messages.Reverse();
            var message = string.Join(Environment.NewLine, messages);
            _ = MessageBox.Show(message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
