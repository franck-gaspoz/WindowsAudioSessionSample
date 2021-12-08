
using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.Sample
{
    public interface ISoundSampleProvider : IAudioPlugHandler
    {
        int BufferLength { get; set; }

        float[] SoundSampleData { get; }

        bool IsDataAvailable { get; }

        int AvailableLength { get; }
    }
}
