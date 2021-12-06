
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterRightViewModel : ModelBase, IVuMeterViewModel, ISoundCaptureHandler
    {
        public ISoundLevelCapture SoundLevelCapture { get; protected set; }

        double _level = 0;

        /// <summary>
        /// level
        /// </summary>
        public double Level
        {
            get => _level;

            set
            {
                _level = value;
                NotifyPropertyChanged();
                InvertedLevel = 1 - _level;
            }
        }

        double _invertedLevel = 1;

        /// <summary>
        /// inverted level
        /// </summary>
        public double InvertedLevel
        {
            get => _invertedLevel;
            
            set
            {
                _invertedLevel = value;
                NotifyPropertyChanged();
            }
        }

        string _label = "C";

        /// <summary>
        /// label
        /// </summary>
        public string Label
        {
            get => _label;

            set
            {
                _label = value;
                NotifyPropertyChanged();
            }
        }

        double _labelWidth = 12;

        /// <summary>
        /// label width
        /// </summary>
        public double LabelWidth
        {
            get => _labelWidth;

            set
            {
                _labelWidth = value;
                NotifyPropertyChanged();
            }
        }

        public void AttachTo(ISoundLevelCapture soundLevelCapture)
            => SoundLevelCapture = soundLevelCapture;

        public void HandleTick()
            => Level = SoundLevelCapture.LevelRight / 20000d;

        void Reset() => Level = 0;

        public void Start() => Reset();

        public void Stop() => Reset();
    }
}