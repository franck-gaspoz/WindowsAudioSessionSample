using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;

using Un4seen.BassWasapi;

namespace WASApiBassNet.Components.AudioCapture
{
    /// <summary>
    /// Audio Plug Engine - audio plugins interactor
    /// </summary>
    public class AudioPluginEngine : IAudioPluginEngine
    {
        /// <inheritdoc/>
        public IWASApi WASApi { get; set; }

        /// <summary>
        /// timer which trigger the audio plugins tick event
        /// </summary>
        DispatcherTimer _dispatcherTimer;

        /// <summary>
        /// sound capture audio plugins, that will be called sequencially
        /// </summary>
        readonly List<IAudioPlugin> _soundCaptureHandlers = new List<IAudioPlugin>();

        /// <summary>
        /// a delay to be applied when before starting and after stoping the audio plugins
        /// </summary>
        const int _activationDelay = 200;

        /// <inheritdoc/>
        public event EventHandler<ExceptionEventArgs> DispatcherTimerEventHandlerError;

        /// <inheritdoc/>
        public AudioPluginEngine AddAudioPlugHandler(IAudioPlugin audioPlugHandler)
        {
            _soundCaptureHandlers.Add(audioPlugHandler);
            return this;
        }

        /// <inheritdoc/>
        public AudioPluginEngine RemoveAudioPlugHandler(IAudioPlugin audioPlugHandler)
        {
            _ = _soundCaptureHandlers.Remove(audioPlugHandler);
            return this;
        }

        /// <summary>
        /// build a new audio plug engine
        /// <para>that can be done if no other engine is already running with same system audio resources</para>
        /// </summary>
        public AudioPluginEngine()
        {
            InitializeDispatcherTimer();
        }

        /// <summary>
        /// initialize the dispatcher timer that triggers ticks for audio plugs
        /// </summary>
        void InitializeDispatcherTimer()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += DispatcherTimerEventHandler;
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(25); //40hz refresh rate
            _dispatcherTimer.IsEnabled = false;
        }

        /// <summary>
        /// the dispatcher timer that runs the audio plug chain
        /// <para>it is stoped if an exception occurs in audio chain treatments</para>
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        void DispatcherTimerEventHandler(object sender, EventArgs e)
        {
            try
            {
                foreach (var soundCaptureHandler in _soundCaptureHandlers)
                    soundCaptureHandler.HandleTick();
            }
            catch (Exception ex)
            {
                DispatcherTimerEventHandlerError?.Invoke(this, new ExceptionEventArgs(ex));
            }
        }

        /// <summary>
        /// starts the audio plug engine (if stopped else does nothing)
        /// </summary>
        /// <param name="soundDeviceIndex">sound device index in sound devices list</param>
        /// <param name="sampleRate">sample rate</param>
        public void Start(int soundDeviceIndex, int sampleRate = 44100)
        {
            if (_dispatcherTimer.IsEnabled)
                return;

            WASApi.InitiliazeSoundCapture(soundDeviceIndex, sampleRate);

            _ = BassWasapi.BASS_WASAPI_Start();

            Thread.Sleep(_activationDelay);
            _dispatcherTimer.IsEnabled = true;

            foreach (var soundCaptureHandler in _soundCaptureHandlers)
                soundCaptureHandler.Start();
        }

        /// <summary>
        /// stops the audio plug engine (if running else does nothing)
        /// </summary>
        public void Stop()
        {
            if (!_dispatcherTimer.IsEnabled)
                return;

            Thread.Sleep(_activationDelay);
            _dispatcherTimer.IsEnabled = false;

            foreach (var soundCaptureHandler in _soundCaptureHandlers)
                soundCaptureHandler.Stop();

            WASApi.StopWasapiCapture();
        }

        /// <summary>
        /// reset the audio plug engine - stop engine and remove all handlers
        /// </summary>
        public void Reset()
        {
            if (_dispatcherTimer.IsEnabled)
                Stop();
            _soundCaptureHandlers.Clear();
        }
    }
}
