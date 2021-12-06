
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
    /// <summary>
    /// audio capture components: add and setup data providers, data transformers, drawers and connect them to controls
    /// </summary>
    public class WASComponents
    {
        public IFFTProvider FFTProvider { get; protected set; }
        public IFFTAnalyzer FFTAnalyser1 { get; protected set; }
        public IFFTAnalyzer FFTAnalyser2 { get; protected set; }
        public IFFTPeakAnalyzer FFTPeakAnalyser2 { get; protected set; }
        public IFFTPeakDrawer FFTPeakDrawer { get; protected set; }
        public AudioPlugEngine SoundCaptureEngine { get; protected set; }
        public ISoundLevelCapture SoundLevelCapture { get; protected set; }
        public ISoundSampleProvider SoundSampleProvider { get; protected set; }

        /// <summary>
        /// add and setup required components, connect to the view and activate the sound capture engine
        /// </summary>
        /// <param name="viewModel">main window view model</param>
        public void BuildComponents(WASMainViewModel viewModel)
        {
            var fftLength = viewModel.FFTResolution.ToSampleLength();
            var sampleLength = viewModel.SampleLength;

            // chain manager

            SoundCaptureEngine = new AudioPlugEngine();

            // FFT

            FFTProvider = new FFTProvider(fftLength);

            // FFT component #1

            var fft1ViewModel = App.WASMainWindow.fftControl1.ViewModel;
            FFTAnalyser1 = new FFTAnalyzer(FFTProvider, fft1ViewModel.BarCount);
            fft1ViewModel.AttachTo(FFTAnalyser1);

            // FFT component #2

            var fft2ViewModel = App.WASMainWindow.fftControl2.ViewModel;
            FFTAnalyser2 = new FFTAnalyzer(FFTProvider, fft2ViewModel.BarCount);
            fft2ViewModel.AttachTo(FFTAnalyser2);
            fft2ViewModel.FFTDrawer.BarBrush
                = HatchRawBrush.Build(Brushes.LightGreen, 4, 3);

            FFTPeakAnalyser2 = new FFTPeakAnalyzer(FFTAnalyser2, fft2ViewModel.BarCount);
            FFTPeakDrawer = new FFTPeakDrawer(App.WASMainWindow.fftControl2) { WidthPercent = 80d };
            FFTPeakDrawer.AttachTo(FFTPeakAnalyser2);

            // Sound Level component

            SoundLevelCapture = new SoundLevelCapture();
            var vuMeterViewModel = App.WASMainWindow.vuMeterControl1.ViewModel;
            vuMeterViewModel.VuMeterLeftViewModel.AttachTo(SoundLevelCapture);
            vuMeterViewModel.VuMeterRightViewModel.AttachTo(SoundLevelCapture);

            // sound sample component

            SoundSampleProvider = new SoundSampleProvider(sampleLength);
            var soundWaveViewModel = App.WASMainWindow.soundWaveControl.ViewModel;
            soundWaveViewModel.AttachTo(SoundSampleProvider);

            // audio capture handlers components chain

            _ = SoundCaptureEngine
                .AddSoundCaptureHandler(SoundSampleProvider)
                .AddSoundCaptureHandler(FFTProvider)

                .AddSoundCaptureHandler(FFTAnalyser1)
                .AddSoundCaptureHandler(fft1ViewModel)

                .AddSoundCaptureHandler(FFTAnalyser2)
                .AddSoundCaptureHandler(fft2ViewModel)
                .AddSoundCaptureHandler(FFTPeakAnalyser2)
                .AddSoundCaptureHandler(FFTPeakDrawer)

                .AddSoundCaptureHandler(SoundLevelCapture)
                .AddSoundCaptureHandler(vuMeterViewModel.VuMeterLeftViewModel)
                .AddSoundCaptureHandler(vuMeterViewModel.VuMeterRightViewModel)

                .AddSoundCaptureHandler(soundWaveViewModel);
        }
    }
}
