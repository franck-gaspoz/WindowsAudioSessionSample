using System;
using System.Collections.Generic;
using System.Windows;

namespace WindowsAudioSession.UI
{
    public class UIHelper
    {
        public static void ShowError(Exception ex)
        {
            var messages = new List<string>() { ex.Message };
            Exception innerException = ex;
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
