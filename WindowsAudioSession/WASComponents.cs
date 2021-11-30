
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

namespace WindowsAudioSession
{
    public class WASComponents
    {
        public FFTProvider FFTProvider { get; set; }

        protected FFTAnalyzer FFTAnalyser { get; set; }

        public SoundListener SoundListener { get; set; }

        public void BuildComponents(SampleLength sampleLength)
        {
            SoundListener = new SoundListener();

            FFTProvider = new FFTProvider(sampleLength);

            FFTAnalyser = new FFTAnalyzer(
                FFTProvider,
                App.WASOverviewWindow.FFTControl1.ViewModel.BarCount);

            App.WASOverviewWindow.FFTControl1.ViewModel.AttachTo(FFTAnalyser);

            _ = SoundListener
                .AddSoundCaptureHandler(FFTProvider)
                .AddSoundCaptureHandler(FFTAnalyser)
                .AddSoundCaptureHandler(App.WASOverviewWindow.FFTControl1.ViewModel);
        }
    }
}
