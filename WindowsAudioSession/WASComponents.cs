
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
        public IFFTAnalyzer FFTAnalyser1 { get; protected set; } = new FFTAnalyzer();
        public IFFTAnalyzer FFTAnalyser2 { get; protected set; } = new FFTAnalyzer();
        public IFFTPeakAnalyzer FFTPeakAnalyser2 { get; protected set; } = new FFTPeakAnalyzer();
        public IFFTPeakDrawer FFTPeakDrawer { get; protected set; } = new FFTPeakDrawer();
        public AudioPlugEngine AudioPlugEngine { get; protected set; }
        public ISoundLevelCapture SoundLevelCapture { get; protected set; }
        public ISoundSampleProvider SoundSampleProvider { get; protected set; }
        public IFFTDrawer FFTDrawer1 { get; protected set; } = new FFTDrawer();
        public IFFTDrawer FFTDrawer2 { get; protected set; } = new FFTDrawer();
        public FFTViewModelDrawerMediator FFTViewModelDrawerMediator { get; protected set; } = new FFTViewModelDrawerMediator();

        /// <summary>
        /// add and setup required components, connect to the view and activate the sound capture engine
        /// </summary>
        /// <param name="viewModel">main window view model</param>
        public void BuildComponents(WASMainViewModel viewModel)
        {
            var fftLength = viewModel.FFTResolution.ToSampleLength();
            var sampleLength = viewModel.SampleLength;

            // chain manager

            AudioPlugEngine = new AudioPlugEngine();

            // FFT

            FFTProvider = new FFTProvider(fftLength);

            // FFT component #1

            var fft1ViewModel = App.WASMainWindow.fftControl1.ViewModel;
            FFTAnalyser1.FFTProvider = FFTProvider;
            FFTAnalyser1.BarsCount = fft1ViewModel.BarCount;
            FFTDrawer1.Drawable = App.WASMainWindow.fftControl1;
            FFTDrawer1.FFTAnalyser = FFTAnalyser1;
            FFTViewModelDrawerMediator.InitializeMediate(fft1ViewModel, FFTDrawer1);

            // FFT component #2

            var fft2ViewModel = App.WASMainWindow.fftControl2.ViewModel;
            FFTAnalyser2.FFTProvider = FFTProvider;
            FFTAnalyser2.BarsCount = fft2ViewModel.BarCount;
            FFTDrawer2.BarBrush = HatchRawBrush.Build(Brushes.LightGreen, 4, 3);
            FFTDrawer2.BarWidthPercent = fft2ViewModel.BarWidthPercent;
            FFTDrawer2.Drawable = App.WASMainWindow.fftControl2;
            FFTDrawer2.FFTAnalyser = FFTAnalyser2;

            FFTPeakAnalyser2.FFTAnalyzer = FFTAnalyser2;
            FFTPeakAnalyser2.BarsCount = fft2ViewModel.BarCount;
            FFTPeakDrawer.WidthPercent = 80d;
            FFTPeakDrawer.Drawable = App.WASMainWindow.fftControl2;
            FFTPeakDrawer.FFTPeakAnalyser = FFTPeakAnalyser2;

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

            _ = AudioPlugEngine
                .AddSoundCaptureHandler(SoundSampleProvider)
                .AddSoundCaptureHandler(FFTProvider)

                .AddSoundCaptureHandler(FFTAnalyser1)
                .AddSoundCaptureHandler(FFTDrawer1)
                .AddSoundCaptureHandler(fft1ViewModel)

                .AddSoundCaptureHandler(FFTAnalyser2)
                .AddSoundCaptureHandler(FFTDrawer2)
                .AddSoundCaptureHandler(FFTPeakAnalyser2)
                .AddSoundCaptureHandler(FFTPeakDrawer)

                .AddSoundCaptureHandler(SoundLevelCapture)
                .AddSoundCaptureHandler(vuMeterViewModel.VuMeterLeftViewModel)
                .AddSoundCaptureHandler(vuMeterViewModel.VuMeterRightViewModel)

                .AddSoundCaptureHandler(soundWaveViewModel);
        }
    }
}
