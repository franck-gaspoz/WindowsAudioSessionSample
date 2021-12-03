
using Un4seen.Bass;
using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.UI;

namespace WindowsAudioSession.Components
{
    public class SoundLevelCapture : ISoundCaptureHandler
    {
        public bool IsStarted { get; protected set; }

        public int LevelLeft { get; protected set; }

        public int LevelRight { get; protected set; }

#if AntiHang
        int _lastLevel;
        int _hanctr;
#endif

        public void HandleTick()
        {
            if (!IsStarted) return;

            var level = BassWasapi.BASS_WASAPI_GetLevel();
            if (level != -1)
            {
                LevelLeft = Utils.LowWord32(level);
                LevelRight = Utils.HighWord32(level);
            }
            else
            {
                Stop();
                UIHelper.ShowError(
                    ExceptionHelper.BuildException(
                        WindowsAudioSessionHelper.BuildAudioApiErrorException("BASS_WASAPI_GetLevel failed")));
            }

#if AntiHang
            if (level == _lastLevel && level != 0) _hanctr++;
            _lastLevel = level;

            //Required, because some programs hang the output. If the output hangs for a 75ms
            //this piece of code re initializes the output so it doesn't make a gliched sound for long.
            if (_hanctr > 3)
            {
                _hanctr = 0;
                LevelLeft = 0;
                LevelRight = 0;
                Free();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                _initialized = false;
                Enable = true;
            }
#endif
        }

        public void Start() {
            IsStarted = true;
        }

        public void Stop() {
            LevelLeft = LevelRight = 0;
            IsStarted = false;
        }
    }
}
