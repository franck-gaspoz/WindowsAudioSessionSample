
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

        public void HandleTick()
        {
            if (!IsStarted) return;

            var level = BassWasapi.BASS_WASAPI_GetLevel();
            if (level == -1)
            {
                Stop();
                UIHelper.ShowError(
                    ExceptionHelper.BuildException(
                        WindowsAudioSessionHelper.BuildAudioApiErrorException("BASS_WASAPI_GetLevel failed")));
            }
            else
            {
                LevelLeft = Utils.LowWord32(level);
                LevelRight = Utils.HighWord32(level);
            }
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Stop()
        {
            LevelLeft = LevelRight = 0;
            IsStarted = false;
        }
    }
}
