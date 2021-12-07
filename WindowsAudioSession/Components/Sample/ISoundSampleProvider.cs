
using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.Sample
{
    public interface ISoundSampleProvider : IAudioPlugHandler
    {
        float[] SoundSampleData { get; }

        bool IsDataAvailable { get; }

        int AvailableLength { get; }
    }
}
