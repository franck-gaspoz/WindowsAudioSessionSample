
using System.Windows.Media;

using WindowsAudioSession.Components;
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.UI;
using WindowsAudioSession.UI.FFT;

using WPFUtilities.CustomBrushes;

namespace WindowsAudioSession
{
    public class WASComponents
    {
        public FFTProvider FFTProvider { get; protected set; }
        public FFTAnalyzer FFTAnalyser1 { get; protected set; }
        public FFTAnalyzer FFTAnalyser2 { get; protected set; }
        public FFTPeakAnalyzer FFTPeakAnalyser2 { get; protected set; }
        public FFTPeakDrawer FFTPeakDrawer2 { get; protected set; }
        public SoundListener SoundListener { get; protected set; }
        public SoundLevelCapture SoundLevelCapture { get; protected set; }
        public SoundSampleProvider SoundSampleProvider { get; protected set; }

        public void BuildComponents(WASOverviewWindowViewModel viewModel)
        {
            var fftLength = viewModel.FFTResolution.ToSampleLength();
            var sampleLength = viewModel.SampleLength;

            // chain manager

            SoundListener = new SoundListener();

            // FFT

            FFTProvider = new FFTProvider(fftLength);

            // FFT component #1

            var fftControl1ViewModel = App.WASOverviewWindow.fftControl1.ViewModel;
            FFTAnalyser1 = new FFTAnalyzer(FFTProvider, fftControl1ViewModel.BarCount);
            fftControl1ViewModel.AttachTo(FFTAnalyser1);

            // FFT component #2

            var fftControl2ViewModel = App.WASOverviewWindow.fftControl2.ViewModel;
            FFTAnalyser2 = new FFTAnalyzer(FFTProvider, fftControl2ViewModel.BarCount);
            fftControl2ViewModel.AttachTo(FFTAnalyser2);
            fftControl2ViewModel.FFTDrawer.BarBrush
                = HatchRawBrush.Build(Brushes.LightGreen, 4, 3);

            FFTPeakAnalyser2 = new FFTPeakAnalyzer(FFTAnalyser2, fftControl2ViewModel.BarCount);
            FFTPeakDrawer2 = new FFTPeakDrawer(App.WASOverviewWindow.fftControl2.BarGraph) { WidthPercent = 80d };
            FFTPeakDrawer2.AttachTo(FFTPeakAnalyser2);

            // Sound Level component

            SoundLevelCapture = new SoundLevelCapture();
            var vuMeterViewModel = App.WASOverviewWindow.vuMeterControl1.ViewModel;
            vuMeterViewModel.AttachTo(SoundLevelCapture);

            // soound sample

            SoundSampleProvider = new SoundSampleProvider(sampleLength);

            // components chain

            _ = SoundListener
                .AddSoundCaptureHandler(SoundSampleProvider)

                .AddSoundCaptureHandler(FFTProvider)

                .AddSoundCaptureHandler(FFTAnalyser1)
                .AddSoundCaptureHandler(fftControl1ViewModel)

                .AddSoundCaptureHandler(FFTAnalyser2)
                .AddSoundCaptureHandler(fftControl2ViewModel)
                .AddSoundCaptureHandler(FFTPeakAnalyser2)
                .AddSoundCaptureHandler(FFTPeakDrawer2)

                .AddSoundCaptureHandler(SoundLevelCapture)
                .AddSoundCaptureHandler(vuMeterViewModel);
        }
    }
}
