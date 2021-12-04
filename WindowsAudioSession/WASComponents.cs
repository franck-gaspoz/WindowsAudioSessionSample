
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.Components;
using System.Windows.Media;

namespace WindowsAudioSession
{
    public class WASComponents
    {
        public FFTProvider FFTProvider { get; protected set; }
        public FFTAnalyzer FFTAnalyser1 { get; protected set; }
        public FFTAnalyzer FFTAnalyser2 { get; protected set; }
        public SoundListener SoundListener { get; protected set; }
        public SoundLevelCapture SoundLevelCapture { get; protected set; }

        public void BuildComponents(FFTLength sampleLength)
        {
            SoundListener = new SoundListener();

            FFTProvider = new FFTProvider(sampleLength);

            FFTAnalyser1 = new FFTAnalyzer( FFTProvider, App.WASOverviewWindow.fftControl1.ViewModel.BarCount);
            App.WASOverviewWindow.fftControl1.ViewModel.AttachTo(FFTAnalyser1);

            FFTAnalyser2 = new FFTAnalyzer(FFTProvider, App.WASOverviewWindow.fftControl2.ViewModel.BarCount);
            App.WASOverviewWindow.fftControl2.ViewModel.AttachTo(FFTAnalyser2);
            App.WASOverviewWindow.fftControl2.ViewModel.FFTDrawer.BarBrush = Brushes.LightGreen;

            SoundLevelCapture = new SoundLevelCapture();
            App.WASOverviewWindow.vuMeterControl1.ViewModel.AttachTo(SoundLevelCapture);

            _ = SoundListener
                .AddSoundCaptureHandler(FFTProvider)

                .AddSoundCaptureHandler(FFTAnalyser1)
                .AddSoundCaptureHandler(App.WASOverviewWindow.fftControl1.ViewModel)

                .AddSoundCaptureHandler(FFTAnalyser2)
                .AddSoundCaptureHandler(App.WASOverviewWindow.fftControl2.ViewModel)

                .AddSoundCaptureHandler(SoundLevelCapture)
                .AddSoundCaptureHandler(App.WASOverviewWindow.vuMeterControl1.ViewModel);
        }
    }
}
