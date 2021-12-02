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
    public class SoundListener
    {
        public ListenableSoundDevices ListenabledSoundDevices { get; protected set; }

        DispatcherTimer _dispatcherTimer;

        readonly WASAPIPROC _process;

        readonly List<ISoundCaptureHandler> _soundCaptureHandlers = new List<ISoundCaptureHandler>();

        const int _activationDelay = 500;

        public SoundListener AddSoundCaptureHandler(ISoundCaptureHandler soundCaptureHandler)
        {
            _soundCaptureHandlers.Add(soundCaptureHandler);
            return this;
        }

        public SoundListener RemoveSoundCaptureHandler(ISoundCaptureHandler soundCaptureHandler)
        {
            _ = _soundCaptureHandlers.Remove(soundCaptureHandler);
            return this;
        }

        public SoundListener()
        {
            _process = new WASAPIPROC(WASAPICaptureCallback);
            InitializeListener();
        }

        void InitializeListener()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += DispatcherTimerEventHandler;
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(25); //40hz refresh rate
            _dispatcherTimer.IsEnabled = false;
        }

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

        public void Stop()
        {
            if (!_dispatcherTimer.IsEnabled)
                return;

            if (!BassWasapi.BASS_WASAPI_Stop(true))
                ThrowsAudioApiErrorException("BassWasapi.BASS_WASAPI_Stop failed");
            if (!BassWasapi.BASS_WASAPI_Free())
                ThrowsAudioApiErrorException("BassWasapi.BASS_WASAPI_Free failed");
            if (!Bass.BASS_Free())
                ThrowsAudioApiErrorException("Bass.BASS_Free failed");
            if (!Bass.FreeMe())
                ThrowsAudioApiErrorException("Bass.FreeMe failed");

            Thread.Sleep(_activationDelay);
            _dispatcherTimer.IsEnabled = false;

            foreach (var soundCaptureHandler in _soundCaptureHandlers)
                soundCaptureHandler.Stop();
        }
    }
}
