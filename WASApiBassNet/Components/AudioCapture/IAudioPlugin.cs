namespace WASApiBassNet.Components.AudioCapture
{
    /// <summary>
    /// audio plugin handler
    /// </summary>
    public interface IAudioPlugin
    {
        /// <summary>
        /// handle the tick event
        /// </summary>
        void HandleTick();

        /// <summary>
        /// starts the audio plugin
        /// </summary>
        void Start();

        /// <summary>
        /// stops the audio plugin
        /// </summary>
        void Stop();
    }
}
