
using WindowsAudioSession.Components;
using WindowsAudioSession.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterViewModel : ModelBase, ISoundCaptureHandler
    {
        SoundLevelCapture _soundLevelCapture;

        double _levelLeft = 0;

        /// <summary>
        /// level left
        /// </summary>
        public double LevelLeft
        {
            get => _levelLeft;

            set
            {
                _levelLeft = value;
                NotifyPropertyChanged();
            }
        }

        double _levelRight = 0;
        /// <summary>
        /// level right
        /// </summary>
        public double LevelRight
        {
            get => _levelRight;

            set
            {
                _levelRight = value;
                NotifyPropertyChanged();
            }
        }

        public VuMeterViewModel() { }

        public void AttachTo(SoundLevelCapture soundLevelCapture)
        {
            _soundLevelCapture = soundLevelCapture;
        }

        public void HandleTick()
        {
            LevelLeft = _soundLevelCapture.LevelLeft / 20000d;
            LevelRight = _soundLevelCapture.LevelRight / 20000d;
        }

        public void Start() { }

        public void Stop() {
            LevelLeft = 0;
            LevelRight = 0;
        }
    }
}
