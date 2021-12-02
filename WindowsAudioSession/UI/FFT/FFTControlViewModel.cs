
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.FFT
{
    public class FFTControlViewModel : ModelBase, ISoundCaptureHandler
    {
        readonly FFTDrawer _fftDrawer;

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
            _fftDrawer = new FFTDrawer(fftControl.BarGraph);
        }

        public void AttachTo(FFTAnalyzer fftAnalyzer)
        {
            _fftDrawer.AttachTo(fftAnalyzer);
        }

        public void HandleTick()
        {
            _fftDrawer.HandleTick();
        }

        public void Start()
        {
            if (IsStarted || !IsValid) return;
            _fftDrawer.Start();
            IsStarted = true;
        }

        public void Stop()
        {
            if (!IsStarted) return;
            _fftDrawer.Stop();
            IsStarted = false;
        }
    }
}
