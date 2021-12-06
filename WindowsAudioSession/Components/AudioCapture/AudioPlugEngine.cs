using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;

using Un4seen.Bass;
using Un4seen.BassWasapi;

using WindowsAudioSession.UI;

using static WindowsAudioSession.Components.WindowsAudioSessionHelper;

using commands = WindowsAudioSession.Commands.Commands;

namespace WindowsAudioSession.Components.AudioCapture
{
    /// <summary>
    /// AudioPlugEngine
    /// <para>might have separated typed initializers (currently have only 'InitiliazeSoundCapture') ?</para>
    /// </summary>
    public class AudioPlugEngine
    {
        public ListenableSoundDevices ListenabledSoundDevices { get; protected set; }

        DispatcherTimer _dispatcherTimer;

        readonly WASAPIPROC _process;

        readonly List<ISoundCaptureHandler> _soundCaptureHandlers = new List<ISoundCaptureHandler>();

        const int _activationDelay = 200;

        public AudioPlugEngine AddSoundCaptureHandler(ISoundCaptureHandler soundCaptureHandler)
        {
            _soundCaptureHandlers.Add(soundCaptureHandler);
            return this;
        }

        public AudioPlugEngine RemoveSoundCaptureHandler(ISoundCaptureHandler soundCaptureHandler)
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
            _process = new WASAPIPROC(WASAPICaptureCallback);
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
        /// initialize audio treatment: sound capture
        /// </summary>
        /// <param name="soundDeviceIndex">sound device index to be listened</param>
        /// <param name="sampleRate">sample rate</param>
        void InitiliazeSoundCapture(int soundDeviceIndex, int sampleRate)
        {
            if (!Bass.BASS_Init(0, sampleRate, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                ThrowsAudioApiErrorException("u4seen.Bass.BASS_Init failed");

            if (!BassWasapi.BASS_WASAPI_Init(
                soundDeviceIndex,
                0,  // mix format sample rate
                0,  // channels (0=mix)
                BASSWASAPIInit.BASS_WASAPI_BUFFER,  // enable double buffering
                1f, // buffer length in seconds
                0.05f,  // callback intervall in seconds
                _process,   // callback
                IntPtr.Zero))
            {
                ThrowsAudioApiErrorException("BASS_WASAPI_Init failed");
            }
        }

        /// <summary>
        /// WASAPI callback, required for continuous recording
        /// </summary>
        /// <param name="buffer">buffer ptr</param>
        /// <param name="length">buffer length</param>
        /// <param name="user">user ptr</param>
        /// <returns>buffer length</returns>
        int WASAPICaptureCallback(IntPtr buffer, int length, IntPtr user)
        {
            return length;
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

            InitiliazeSoundCapture(soundDeviceIndex, sampleRate);

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

            if (!BassWasapi.BASS_WASAPI_Stop(true))
                ThrowsAudioApiErrorException("BassWasapi.BASS_WASAPI_Stop failed");
            if (!BassWasapi.BASS_WASAPI_Free())
                ThrowsAudioApiErrorException("BassWasapi.BASS_WASAPI_Free failed");
            if (!Bass.BASS_Free())
                ThrowsAudioApiErrorException("Bass.BASS_Free failed");
            if (!Bass.FreeMe())
                ThrowsAudioApiErrorException("Bass.FreeMe failed");
        }
    }
}
