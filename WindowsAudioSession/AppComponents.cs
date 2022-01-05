
using System.Windows.Media;

using WASApiBassNet.Components.AudioCapture;
using WASApiBassNet.Components.FFT;
using WASApiBassNet.Components.Sample;
using WASApiBassNet.Components.SoundLevel;

using WindowsAudioSession.UI;
using WindowsAudioSession.UI.FFT;
using WindowsAudioSession.UI.SoundLevel;
using WindowsAudioSession.UI.SoundWave;

using WPFUtilities.CustomBrushes;

namespace WindowsAudioSession
{
    /// <summary>
    /// audio capture components: add and setup views models and models: data providers, data transformers, drawers and connect them to controls
    /// </summary>
    public class AppComponents : IAppComponents
    {
        #region properties

        /// <summary>
        /// audio plugin interactor
        /// </summary>
        public IAudioPluginEngine AudioPluginEngine { get; protected set; } = new AudioPluginEngine();

        /// <summary>
        /// wasapi facade
        /// </summary>
        public IWASApi WASApi { get; protected set; } = new WASApi();

        /// <summary>
        /// fft data provider
        /// </summary>
        public IFFTProvider FFTProvider { get; protected set; } = new FFTProvider();

        /// <summary>
        /// fft analyzer 1
        /// </summary>
        public IFFTAnalyzer FFTAnalyser1 { get; protected set; } = new FFTAnalyzer();

        /// <summary>
        /// fft analyzer 2
        /// </summary>
        public IFFTAnalyzer FFTAnalyser2 { get; protected set; } = new FFTAnalyzer();

        /// <summary>
        /// fft peak analyzer
        /// </summary>
        public IFFTPeakAnalyzer FFTPeakAnalyser2 { get; protected set; } = new FFTPeakAnalyzer();

        /// <summary>
        /// fft peak drawer
        /// </summary>
        public IFFTPeakDrawer FFTPeakDrawer { get; protected set; } = new FFTPeakDrawer();

        /// <summary>
        /// sound level capture data provider
        /// </summary>
        public ISoundLevelCapture SoundLevelCapture { get; protected set; } = new SoundLevelCapture();

        /// <summary>
        /// sound capture sample data provider
        /// </summary>
        public ISoundSampleProvider SoundSampleProvider { get; protected set; } = new SoundSampleProvider();

        /// <summary>
        /// fft drawer 1
        /// </summary>
        public IFFTDrawer FFTDrawer1 { get; protected set; } = new FFTDrawer();

        /// <summary>
        /// fft drawer 2
        /// </summary>
        public IFFTDrawer FFTDrawer2 { get; protected set; } = new FFTDrawer();

        /// <summary>
        /// fft view model drawer mediator
        /// </summary>
        public FFTViewModelDrawerMediator FFTViewModelDrawerMediator { get; protected set; } = new FFTViewModelDrawerMediator();

        /// <summary>
        /// fft vie model 1
        /// </summary>
        public IFFTViewModel FFTViewModel1 { get; protected set; } = new FFTViewModel();

        /// <summary>
        /// fft view model 2
        /// </summary>
        public IFFTViewModel FFTViewModel2 { get; protected set; } = new FFTViewModel();

        /// <summary>
        /// sound wave view model
        /// </summary>
        public ISoundWaveViewModel SoundWaveViewModel { get; protected set; } = new SoundWaveViewModel();

        /// <summary>
        /// sound wave drawer
        /// </summary>
        public ISoundWaveDrawer SoundWaveDrawer { get; protected set; } = new SoundWaveDrawer();

        /// <summary>
        /// vumeter stereo view model
        /// </summary>
        public IVuMeterStereoViewModel VuMeterStereoViewModel { get; protected set; } = new VuMeterStereoViewModel();

        #endregion

        /// <summary>
        /// add and setup required components, connect them together and activate the sound capture engine
        /// </summary>
        /// <param name="viewModel">main window view model</param>
        public void BuildComponents(IWASMainViewModel viewModel)
        {
            var fftLength = viewModel.FFTResolution.ToSampleLength();
            var sampleLength = viewModel.SampleLength;

            // WASApi facade

            AudioPluginEngine.WASApi = WASApi;

            // chain manager

            AudioPluginEngine.Reset();

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
            FFTDrawer2.BarBrush = HatchRawBrush.Create(Brushes.LightGreen, 4, 3);
            FFTDrawer2.BarWidthPercent = FFTViewModel2.BarWidthPercent;
            FFTDrawer2.Drawable = App.WASMainWindow.fftControl2;
            FFTDrawer2.FFTAnalyser = FFTAnalyser2;

            FFTPeakAnalyser2.FFTAnalyzer = FFTAnalyser2;
            FFTPeakAnalyser2.BarsCount = FFTViewModel2.BarCount;
            FFTPeakDrawer.WidthPercent = 80d;
            FFTPeakDrawer.Drawable = App.WASMainWindow.fftControl2;
            FFTPeakDrawer.FFTPeakAnalyser = FFTPeakAnalyser2;

            // Sound Level component

            App.WASMainWindow.vuMeterControl1.ViewModel = VuMeterStereoViewModel;
            VuMeterStereoViewModel.VuMeterLeftViewModel.SoundLevelCapture = SoundLevelCapture;
            VuMeterStereoViewModel.VuMeterRightViewModel.SoundLevelCapture = SoundLevelCapture;

            // sound sample component

            SoundSampleProvider.BufferLength = sampleLength;
            App.WASMainWindow.soundWaveControl.ViewModel = SoundWaveViewModel;
            SoundWaveDrawer.Drawable = App.WASMainWindow.soundWaveControl;
            SoundWaveDrawer.SoundSampleProvider = SoundSampleProvider;

            // audio capture handlers components chain

            _ = AudioPluginEngine
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
                .AddAudioPlugHandler(VuMeterStereoViewModel.VuMeterLeftViewModel)
                .AddAudioPlugHandler(VuMeterStereoViewModel.VuMeterRightViewModel)

                .AddAudioPlugHandler(SoundWaveDrawer);
        }
    }
}
