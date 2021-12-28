using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;

using Un4seen.BassWasapi;

using WindowsAudioSession.UI;

using commands = WindowsAudioSession.Commands.Commands;

namespace WindowsAudioSession.Components.AudioCapture
{
    /// <summary>
    /// AudioPlugEngine
    /// <para>might have separated typed initializers (currently have only 'InitiliazeSoundCapture') ?</para>
    /// <para>the audio plug engine should be separated from the sound apis initializer.
    /// that would allow to runs several engine parrallely</para>
    /// </summary>
    public class AudioPlugEngine
    {
        public IWASApi WASApi { get; set; }

        public ListenableSoundDevices ListenabledSoundDevices { get; protected set; }

        DispatcherTimer _dispatcherTimer;

        readonly List<IAudioPlugHandler> _soundCaptureHandlers = new List<IAudioPlugHandler>();

        const int _activationDelay = 200;

        public AudioPlugEngine AddAudioPlugHandler(IAudioPlugHandler soundCaptureHandler)
        {
            _soundCaptureHandlers.Add(soundCaptureHandler);
            return this;
        }

        public AudioPlugEngine RemoveAudioPlugHandler(IAudioPlugHandler soundCaptureHandler)
        {
            _ = _soundCaptureHandlers.Remove(soundCaptureHandler);
            return this;
        }

        /// <summary>
        /// build a new audio plug engine
        /// <para>that can be done if no other engine is already running with same system audio resources</para>
        /// </summary>
        public AudioPlugEngine()
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DispatcherTimerEventHandler(object sender, EventArgs e)
        {
            try
            {
                foreach (var soundCaptureHandler in _soundCaptureHandlers)
                    soundCaptureHandler.HandleTick();
            }
            catch (Exception ex)
            {
                UIHelper.ShowError(ex);
                commands.Stop.Execute(null);
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

        public void Reset()
        {
            if (_dispatcherTimer.IsEnabled)
                Stop();
            _soundCaptureHandlers.Clear();
        }
    }
}
