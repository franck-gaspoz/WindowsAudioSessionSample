using System.Windows;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.Sample;

namespace WindowsAudioSession.UI.SoundWave
{
    public interface ISoundWaveViewModel : IAudioPlugHandler
    {
        ISoundWaveDrawer SoundWaveDrawer { get; }

        Thickness DrawMargin { get; set; }

        bool IsStarted { get; }

        void AttachTo(ISoundSampleProvider soundSampleProvider);
    }
}
