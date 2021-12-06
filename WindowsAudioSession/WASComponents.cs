
using System.Windows.Media;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.Components.Sample;
using WindowsAudioSession.Components.SoundLevel;
using WindowsAudioSession.UI;
using WindowsAudioSession.UI.FFT;

using WPFUtilities.CustomBrushes;

namespace WindowsAudioSession
{
    public class WASComponents
    {
        public IFFTProvider FFTProvider { get; protected set; }
        public IFFTAnalyzer FFTAnalyser1 { get; protected set; }
        public IFFTAnalyzer FFTAnalyser2 { get; protected set; }
        public IFFTPeakAnalyzer FFTPeakAnalyser2 { get; protected set; }
        public IFFTPeakDrawer FFTPeakDrawer { get; protected set; }
        public SoundCaptureEngine SoundListener { get; protected set; }
        public ISoundLevelCapture SoundLevelCapture { get; protected set; }
        public ISoundSampleProvider SoundSampleProvider { get; protected set; }

        public void BuildComponents(WASMainViewModel viewModel)
        {
            var fftLength = viewModel.FFTResolution.ToSampleLength();
            var sampleLength = viewModel.SampleLength;

            // chain manager

            SoundListener = new SoundCaptureEngine();

            // FFT

            FFTProvider = new FFTProvider(fftLength);

            // FFT component #1

            var fft1ViewModel = App.WASOverviewWindow.fftControl1.ViewModel;
            FFTAnalyser1 = new FFTAnalyzer(FFTProvider, fft1ViewModel.BarCount);
            fft1ViewModel.AttachTo(FFTAnalyser1);

            // FFT component #2

            var fft2ViewModel = App.WASOverviewWindow.fftControl2.ViewModel;
            FFTAnalyser2 = new FFTAnalyzer(FFTProvider, fft2ViewModel.BarCount);
            fft2ViewModel.AttachTo(FFTAnalyser2);
            fft2ViewModel.FFTDrawer.BarBrush
                = HatchRawBrush.Build(Brushes.LightGreen, 4, 3);

            FFTPeakAnalyser2 = new FFTPeakAnalyzer(FFTAnalyser2, fft2ViewModel.BarCount);
            FFTPeakDrawer = new FFTPeakDrawer(App.WASOverviewWindow.fftControl2) { WidthPercent = 80d };
            FFTPeakDrawer.AttachTo(FFTPeakAnalyser2);

            // Sound Level component

            SoundLevelCapture = new SoundLevelCapture();
            var vuMeterViewModel = App.WASOverviewWindow.vuMeterControl1.ViewModel;
            vuMeterViewModel.AttachTo(SoundLevelCapture);

            // soound sample

            SoundSampleProvider = new SoundSampleProvider(sampleLength);
            var soundWaveViewModel = App.WASOverviewWindow.soundWaveControl.ViewModel;
            soundWaveViewModel.AttachTo(SoundSampleProvider);

            // components chain

            _ = SoundListener
                .AddSoundCaptureHandler(SoundSampleProvider)
                .AddSoundCaptureHandler(FFTProvider)

                .AddSoundCaptureHandler(FFTAnalyser1)
                .AddSoundCaptureHandler(fft1ViewModel)

                .AddSoundCaptureHandler(FFTAnalyser2)
                .AddSoundCaptureHandler(fft2ViewModel)
                .AddSoundCaptureHandler(FFTPeakAnalyser2)
                .AddSoundCaptureHandler(FFTPeakDrawer)

                .AddSoundCaptureHandler(SoundLevelCapture)
                .AddSoundCaptureHandler(vuMeterViewModel)

                .AddSoundCaptureHandler(soundWaveViewModel);
        }
    }
}
