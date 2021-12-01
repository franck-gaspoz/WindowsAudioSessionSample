using System;
using System.Runtime.CompilerServices;

namespace WindowsAudioSession.Components
{
    public static class ExceptionHelper
    {
        public static Exception BuildException(
            Exception exception,
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = -1,
            [CallerFilePath] string callerFilePath = "")
            => new Exception($"\nmember: {callerMemberName}\nfile: {callerFilePath}\nline: {callerLineNumber}\n", exception);
    }
}
