
using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.SoundLevel
{
    public interface ISoundLevelCapture : IAudioPlugHandler
    {
        bool IsStarted { get; }

        int LevelLeft { get; }

        int LevelRight { get; }

    }
}
