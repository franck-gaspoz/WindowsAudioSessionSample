
using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.SoundLevel
{
    /// <summary>
    /// sound level capture data provider
    /// </summary>
    public interface ISoundLevelCapture : IAudioPlugin
    {
        /// <summary>
        /// indicates if the sound level capture audio plugin is started or not
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// stereo left channel level
        /// </summary>

        int LevelLeft { get; }

        /// <summary>
        /// stereo right channel level
        /// </summary>

        int LevelRight { get; }

    }
}
