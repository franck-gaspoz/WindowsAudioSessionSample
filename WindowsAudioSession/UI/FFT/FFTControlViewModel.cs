
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.FFT
{
    public class FFTControlViewModel : ModelBase, ISoundCaptureHandler
    {
        public FFTDrawer FFTDrawer { get; protected set; }

        int _barCount = 512;

        /// <summary>
        /// bar count
        /// </summary>
        [BarsCountValidation]
        public int BarCount
        {
            get => _barCount;

            set
            {
                _barCount = value;
                NotifyPropertyChanged();
            }
        }

        int _barWidthPercent = 100;

        /// <summary>
        /// bar width percent
        /// </summary>
        public int BarWidthPercent
        {
            get => _barWidthPercent;
            set
            {
                _barWidthPercent = value;
                NotifyPropertyChanged();
            }
        }

        bool _isStarted = false;

        /// <summary>
        /// is started
        /// </summary>
        public bool IsStarted
        {
            get => _isStarted;

            set
            {
                _isStarted = value;
                NotifyPropertyChanged();
            }
        }

        public FFTControlViewModel(FFTControl fftControl)
        {
            FFTDrawer = new FFTDrawer(fftControl.BarGraph);
        }

        public void AttachTo(FFTAnalyzer fftAnalyzer)
        {
            FFTDrawer.AttachTo(fftAnalyzer);
        }

        public void HandleTick()
        {
            FFTDrawer.WidthPercent = BarWidthPercent;
            FFTDrawer.HandleTick();
        }

        public void Start()
        {
            if (IsStarted) return;
            Validate();
            if (!IsValid) return;
            FFTDrawer.Start();
            IsStarted = true;
        }

        public void Stop()
        {
            if (!IsStarted) return;
            FFTDrawer.Stop();
            IsStarted = false;
        }
    }
}
