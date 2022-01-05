using System;

namespace WASApiBassNet
{
    /// <summary>
    /// exception event arguments
    /// </summary>
    public class ExceptionEventArgs : EventArgs
    {
        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="exception">exception</param>
        public ExceptionEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}
