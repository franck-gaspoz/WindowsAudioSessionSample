
using Un4seen.Bass;
using Un4seen.BassWasapi;

using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.SoundLevel
{
    public class SoundLevelCapture : ISoundLevelCapture, IAudioPlugin
    {
        /// <inheritdoc/>
        public bool IsStarted { get; protected set; }

        /// <inheritdoc/>
        public int LevelLeft { get; protected set; }

        /// <inheritdoc/>
        public int LevelRight { get; protected set; }

        /// <inheritdoc/>
        public void HandleTick()
        {
            if (!IsStarted) return;

            var level = BassWasapi.BASS_WASAPI_GetLevel();
            if (level == -1)
            {
                Stop();
                WASApiBassNetHelper.ThrowsAudioApiErrorException("BASS_WASAPI_GetLevel failed");
            }
            else
            {
                LevelLeft = Utils.LowWord32(level);
                LevelRight = Utils.HighWord32(level);
            }
        }

        /// <inheritdoc/>
        public void Start()
        {
            IsStarted = true;
        }

        /// <inheritdoc/>
        public void Stop()
        {
            LevelLeft = LevelRight = 0;
            IsStarted = false;
        }
    }
}
