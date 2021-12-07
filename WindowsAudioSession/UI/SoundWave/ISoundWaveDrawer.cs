using System.Windows.Media;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.Sample;

namespace WindowsAudioSession.UI.SoundWave
{
    public interface ISoundWaveDrawer : IAudioPlugHandler
    {
        bool IsStarted { get; }

        double Margin { get; set; }

        double Resolution { get; set; }

        Brush LineBrush { get; set; }

        double ScaleFactor { get; set; }

        void AttachTo(ISoundSampleProvider soundSampleProvider);
    }
}
