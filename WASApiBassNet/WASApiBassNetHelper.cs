using System;

using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace WASApiBassNet
{
    /// <summary>
    /// helper methods for WASApiBassNet
    /// </summary>
    public static class WASApiBassNetHelper
    {
        /// <summary>
        /// throw an exception related to audio api
        /// </summary>
        /// <exception cref="InvalidOperationException">invalid operation exception describing the audio error</exception>
        /// <param name="reason">error reason</param>
        public static void ThrowsAudioApiErrorException(string reason)
            => throw BuildAudioApiErrorException(reason);

        /// <summary>
        /// build an exception related to audio api
        /// </summary>
        /// <param name="reason">error reason</param>
        /// <returns>invalid operation exception</returns>
        public static Exception BuildAudioApiErrorException(string reason)
        {
            var errorCode = Bass.BASS_ErrorGetCode();
            return new InvalidOperationException($"error: {reason}. Error code = {errorCode}");
        }

        /// <summary>
        /// free WASApiBassNet resources
        /// </summary>
        /// <exception cref="InvalidOperationException">BASS_WASAPI_Free failed</exception>
        /// <exception cref="InvalidOperationException">BASS_Free failed</exception>
        public static void FreeBassWasapi()
        {
            if (!BassWasapi.BASS_WASAPI_Free())
                ThrowsAudioApiErrorException("BASS_WASAPI_Free failed");
            if (!Bass.BASS_Free())
                ThrowsAudioApiErrorException("BASS_Free failed");
        }

    }
}
