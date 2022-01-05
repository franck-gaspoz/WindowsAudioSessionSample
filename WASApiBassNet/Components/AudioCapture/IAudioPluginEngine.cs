using System;

namespace WASApiBassNet.Components.AudioCapture
{
    public interface IAudioPluginEngine
    {
        /// <summary>
        /// wasapi facade
        /// </summary>
        IWASApi WASApi { get; set; }

        /// <summary>
        /// adds a sound capture plugin
        /// </summary>
        /// <param name="audioPlugHandler">audio handler plugin</param>
        /// <returns>audio interactor</returns>
        AudioPluginEngine AddAudioPlugHandler(IAudioPlugin audioPlugHandler);

        /// <summary>
        /// remove a sound capture plugin
        /// </summary>
        /// <param name="audioPlugHandler">audio handler plugin</param>
        /// <returns>audio interactor</returns>
        AudioPluginEngine RemoveAudioPlugHandler(IAudioPlugin audioPlugHandler);

        /// <summary>
        /// error during dispatcher timer dispatch operation
        /// </summary>
        event EventHandler<ExceptionEventArgs> DispatcherTimerEventHandlerError;

        /// <summary>
        /// reset the audio interactor
        /// </summary>
        void Reset();

        /// <summary>
        /// starts the audio interactor
        /// </summary>
        /// <param name="soundDeviceIndex">sound device index</param>
        /// <param name="sampleRate">sample rate</param>
        void Start(int soundDeviceIndex, int sampleRate = 44100);

        /// <summary>
        /// stops the audio interactor
        /// </summary>
        void Stop();
    }
}