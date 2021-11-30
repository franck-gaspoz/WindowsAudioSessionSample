
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.UI.FFT;

namespace WindowsAudioSession
{
    public class WASComponents
    {
        public FFTAnalyzer FFTAnalyser { get; set; }

        public SoundListener SoundListener { get; set; }

        public void BuildComponents(
            SampleLength sampleLength,
            int barCount)
        {
            SoundListener = new SoundListener();
            FFTAnalyser = new FFTAnalyzer(
                sampleLength,
                barCount);

            App.WASOverviewWindow.FFTControl1.ViewModel.AttachTo(FFTAnalyser);

            _ = SoundListener
                .AddSoundCaptureHandler(FFTAnalyser)
                .AddSoundCaptureHandler(App.WASOverviewWindow.FFTControl1.ViewModel);
        }
    }
}
