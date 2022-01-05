using System;
using System.Runtime.CompilerServices;

namespace WASApiBassNet
{
    /// <summary>
    /// exception helpers
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// build an exception from caller informations
        /// </summary>
        /// <param name="exception">exception initiating this build</param>
        /// <param name="callerMemberName">caller member name</param>
        /// <param name="callerLineNumber">caller line number</param>
        /// <param name="callerFilePath">caller file path</param>
        /// <returns></returns>
        public static Exception BuildException(
            Exception exception,
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = -1,
            [CallerFilePath] string callerFilePath = "")
            => new Exception($"\nmember: {callerMemberName}\nfile: {callerFilePath}\nline: {callerLineNumber}\n", exception);
    }
}
