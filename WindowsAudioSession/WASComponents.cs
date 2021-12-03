
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.Components;

namespace WindowsAudioSession
{
    public class WASComponents
    {
        public FFTProvider FFTProvider { get; protected set; }

        public FFTAnalyzer FFTAnalyser { get; protected set; }

        public SoundListener SoundListener { get; protected set; }

        public SoundLevelCapture SoundLevelCapture { get; protected set; }

        public void BuildComponents(FFTLength sampleLength)
        {
            SoundListener = new SoundListener();

            FFTProvider = new FFTProvider(sampleLength);

            FFTAnalyser = new FFTAnalyzer( FFTProvider, App.WASOverviewWindow.fftControl1.ViewModel.BarCount);
            App.WASOverviewWindow.fftControl1.ViewModel.AttachTo(FFTAnalyser);

            SoundLevelCapture = new SoundLevelCapture();
            App.WASOverviewWindow.vuMeterControl1.ViewModel.AttachTo(SoundLevelCapture);

            _ = SoundListener
                .AddSoundCaptureHandler(FFTProvider)
                .AddSoundCaptureHandler(FFTAnalyser)
                .AddSoundCaptureHandler(App.WASOverviewWindow.fftControl1.ViewModel)
                .AddSoundCaptureHandler(SoundLevelCapture)
                .AddSoundCaptureHandler(App.WASOverviewWindow.vuMeterControl1.ViewModel);
        }
    }
}
