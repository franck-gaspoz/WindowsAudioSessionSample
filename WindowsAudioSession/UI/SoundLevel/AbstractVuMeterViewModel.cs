using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.SoundLevel;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public abstract class AbstractVuMeterViewModel : ModelBase, IModelBase, IAudioPlugHandler
    {
        public double LevelScaleFactor { get; set; } = 1d / 20000d;

        public ISoundLevelCapture SoundLevelCapture { get; set; }

        protected double _level = 0;

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

        protected double _invertedLevel = 1;

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

        protected string _label = "?";

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

        protected double _labelWidth = 12;

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

        public abstract void HandleTick();

        protected void Reset() => Level = 0;

        public void Start() => Reset();

        public void Stop() => Reset();

    }
}
