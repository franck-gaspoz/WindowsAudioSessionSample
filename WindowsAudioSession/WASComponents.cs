
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.UI.FFT;

namespace WindowsAudioSession
{
    public class WASComponents
    {
        public FFTAnalyzer FFTAnalyser { get; set; }

        public SoundListener SoundListener { get; set; }

        public FFTDrawer FFTDrawer { get; set; }

        public void BuildComponents(
            SampleLength sampleLength,
            int barCount)
        {
            SoundListener = new SoundListener();
            FFTAnalyser = new FFTAnalyzer(
                sampleLength,
                barCount);

            FFTDrawer = new FFTDrawer(
                App.WASOverviewWindow.BarGraph,
                FFTAnalyser);

            _ = SoundListener
                .AddSoundCaptureHandler(FFTAnalyser)
                .AddSoundCaptureHandler(FFTDrawer);
        }
    }
}
