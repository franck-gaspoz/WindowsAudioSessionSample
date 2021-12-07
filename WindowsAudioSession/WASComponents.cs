
using System.Windows.Media;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.Components.Sample;
using WindowsAudioSession.Components.SoundLevel;
using WindowsAudioSession.UI;
using WindowsAudioSession.UI.FFT;
using WindowsAudioSession.UI.SoundWave;

using WPFUtilities.CustomBrushes;

namespace WindowsAudioSession
{
    /// <summary>
    /// audio capture components: add and setup data providers, data transformers, drawers and connect them to controls
    /// </summary>
    public class WASComponents
    {
        public AudioPlugEngine AudioPlugEngine { get; protected set; } = new AudioPlugEngine();
        public IFFTProvider FFTProvider { get; protected set; } = new FFTProvider();
        public IFFTAnalyzer FFTAnalyser1 { get; protected set; } = new FFTAnalyzer();
        public IFFTAnalyzer FFTAnalyser2 { get; protected set; } = new FFTAnalyzer();
        public IFFTPeakAnalyzer FFTPeakAnalyser2 { get; protected set; } = new FFTPeakAnalyzer();
        public IFFTPeakDrawer FFTPeakDrawer { get; protected set; } = new FFTPeakDrawer();
        public ISoundLevelCapture SoundLevelCapture { get; protected set; }
        public ISoundSampleProvider SoundSampleProvider { get; protected set; } = new SoundSampleProvider();
        public IFFTDrawer FFTDrawer1 { get; protected set; } = new FFTDrawer();
        public IFFTDrawer FFTDrawer2 { get; protected set; } = new FFTDrawer();
        public FFTViewModelDrawerMediator FFTViewModelDrawerMediator { get; protected set; } = new FFTViewModelDrawerMediator();
        public IFFTViewModel FFTViewModel1 { get; protected set; } = new FFTViewModel();
        public IFFTViewModel FFTViewModel2 { get; protected set; } = new FFTViewModel();
        public ISoundWaveViewModel SoundWaveViewModel { get; protected set; } = new SoundWaveViewModel();
        public ISoundWaveDrawer SoundWaveDrawer { get; protected set; } = new SoundWaveDrawer();

        /// <summary>
        /// add and setup required components, connect to the view and activate the sound capture engine
        /// </summary>
        /// <param name="viewModel">main window view model</param>
        public void BuildComponents(WASMainViewModel viewModel)
        {
            var fftLength = viewModel.FFTResolution.ToSampleLength();
            var sampleLength = viewModel.SampleLength;

            // chain manager

            AudioPlugEngine.Reset();

            // FFT

            FFTProvider.FFTLength = fftLength;

            // FFT component #1

            App.WASMainWindow.fftControl1.ViewModel = FFTViewModel1;
            FFTAnalyser1.FFTProvider = FFTProvider;
            FFTAnalyser1.BarsCount = FFTViewModel1.BarCount;
            FFTDrawer1.Drawable = App.WASMainWindow.fftControl1;
            FFTDrawer1.FFTAnalyser = FFTAnalyser1;
            FFTViewModelDrawerMediator.InitializeMediate(FFTViewModel1, FFTDrawer1);

            // FFT component #2

            App.WASMainWindow.fftControl2.ViewModel = FFTViewModel2;
            FFTAnalyser2.FFTProvider = FFTProvider;
            FFTAnalyser2.BarsCount = FFTViewModel2.BarCount;
            FFTDrawer2.BarBrush = HatchRawBrush.Build(Brushes.LightGreen, 4, 3);
            FFTDrawer2.BarWidthPercent = FFTViewModel2.BarWidthPercent;
            FFTDrawer2.Drawable = App.WASMainWindow.fftControl2;
            FFTDrawer2.FFTAnalyser = FFTAnalyser2;

            FFTPeakAnalyser2.FFTAnalyzer = FFTAnalyser2;
            FFTPeakAnalyser2.BarsCount = FFTViewModel2.BarCount;
            FFTPeakDrawer.WidthPercent = 80d;
            FFTPeakDrawer.Drawable = App.WASMainWindow.fftControl2;
            FFTPeakDrawer.FFTPeakAnalyser = FFTPeakAnalyser2;

            // Sound Level component

            SoundLevelCapture = new SoundLevelCapture();
            var vuMeterViewModel = App.WASMainWindow.vuMeterControl1.ViewModel;
            vuMeterViewModel.VuMeterLeftViewModel.AttachTo(SoundLevelCapture);
            vuMeterViewModel.VuMeterRightViewModel.AttachTo(SoundLevelCapture);

            // sound sample component

            SoundSampleProvider.BufferLength = sampleLength;
            App.WASMainWindow.soundWaveControl.ViewModel = SoundWaveViewModel;
            SoundWaveDrawer.Drawable = App.WASMainWindow.soundWaveControl;
            SoundWaveDrawer.SoundSampleProvider = SoundSampleProvider;

            // audio capture handlers components chain

            _ = AudioPlugEngine
                .AddAudioPlugHandler(SoundSampleProvider)
                .AddAudioPlugHandler(FFTProvider)

                .AddAudioPlugHandler(FFTAnalyser1)
                .AddAudioPlugHandler(FFTDrawer1)
                .AddAudioPlugHandler(FFTViewModel1)

                .AddAudioPlugHandler(FFTAnalyser2)
                .AddAudioPlugHandler(FFTDrawer2)
                .AddAudioPlugHandler(FFTPeakAnalyser2)
                .AddAudioPlugHandler(FFTPeakDrawer)

                .AddAudioPlugHandler(SoundLevelCapture)
                .AddAudioPlugHandler(vuMeterViewModel.VuMeterLeftViewModel)
                .AddAudioPlugHandler(vuMeterViewModel.VuMeterRightViewModel)

                .AddAudioPlugHandler(SoundWaveDrawer);
        }
    }
}
