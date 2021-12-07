
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.FFT
{
    public class FFTViewModel : ModelBase, IFFTViewModel
    { 
        int _barCount = 512;

        /// <summary>
        /// bar count
        /// </summary>
        [BarsCountInAllowableRange]
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

            protected set
            {
                _isStarted = value;
                NotifyPropertyChanged();
            }
        }

        /*
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
        */
    }
}
