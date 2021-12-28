using System;

using Un4seen.Bass;
using Un4seen.BassWasapi;

using static WindowsAudioSession.Components.WindowsAudioSessionHelper;

namespace WindowsAudioSession.Components.AudioCapture
{
    /// <summary>
    /// facade for WASAPI
    /// </summary>
    public class WASApi : IWASApi
    {
        readonly WASAPIPROC _process;

        public WASApi()
        {
            _process = new WASAPIPROC(WASAPICaptureCallback);
        }

        /// <summary>
        /// initialize audio treatment: sound capture
        /// </summary>
        /// <param name="soundDeviceIndex">sound device index to be listened</param>
        /// <param name="sampleRate">sample rate</param>
        public void InitiliazeSoundCapture(int soundDeviceIndex, int sampleRate)
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
        /// stop wasapi capture and free resources
        /// </summary>
        public void StopWasapiCapture()
        {
            if (!BassWasapi.BASS_WASAPI_Stop(true))
                ThrowsAudioApiErrorException("BassWasapi.BASS_WASAPI_Stop failed");
            if (!BassWasapi.BASS_WASAPI_Free())
                ThrowsAudioApiErrorException("BassWasapi.BASS_WASAPI_Free failed");
            if (!Bass.BASS_Free())
                ThrowsAudioApiErrorException("Bass.BASS_Free failed");
            if (!Bass.FreeMe())
                ThrowsAudioApiErrorException("Bass.FreeMe failed");
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
    }
}
