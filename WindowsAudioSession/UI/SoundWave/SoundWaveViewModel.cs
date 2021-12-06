using System.Windows;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.Sample;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundWave
{
    public class SoundWaveViewModel : ModelBase, ISoundCaptureHandler
    {
        public ISoundWaveDrawer SoundWaveDrawer { get; protected set; }

        Thickness _drawMargin = new Thickness(8);

        /// <summary>
        /// draw margin
        /// </summary>
        public Thickness DrawMargin
        {
            get => _drawMargin;

            set
            {
                _drawMargin = value;
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

        public SoundWaveViewModel(IDrawable drawable)
            => SoundWaveDrawer = new SoundWaveDrawer(drawable);

        public void AttachTo(ISoundSampleProvider soundSampleProvider)
            => SoundWaveDrawer.AttachTo(soundSampleProvider);

        public void HandleTick()
            => SoundWaveDrawer.HandleTick();

        public void Start()
        {
            if (IsStarted) return;
            SoundWaveDrawer.Start();
            IsStarted = true;
        }

        public void Stop()
        {
            if (!IsStarted) return;
            SoundWaveDrawer.Stop();
            IsStarted = false;
        }
    }
}
