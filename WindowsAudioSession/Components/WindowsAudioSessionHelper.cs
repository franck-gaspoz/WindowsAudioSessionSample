using System;

using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace WindowsAudioSession.Components
{
    public static class WindowsAudioSessionHelper
    {
        public static void ThrowsAudioApiErrorException(string reason)
        {
            var errorCode = Bass.BASS_ErrorGetCode();
            throw new InvalidOperationException($"error: {reason}. Error code = {errorCode}");
        }

        public static void FreeBassWasapi()
        {
            if (!BassWasapi.BASS_WASAPI_Free())
                ThrowsAudioApiErrorException("BASS_WASAPI_Free failed");
            if (!Bass.BASS_Free())
                ThrowsAudioApiErrorException("BASS_Free failed");
        }
    }
}
