using WASApiBassNet.Components.AudioCapture;
using WASApiBassNet.Components.SoundLevel;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vumeter vieww model abstraction
    /// </summary>
    public abstract class AbstractVuMeterViewModel : ModelBase, IModelBase, IAudioPlugin
    {
        /// <summary>
        /// level scale factor
        /// </summary>
        public double LevelScaleFactor { get; set; } = 1d / 20000d;

        /// <summary>
        /// sound level capture data provider
        /// </summary>
        public ISoundLevelCapture SoundLevelCapture { get; set; }

        /// <summary>
        /// level property backing field
        /// </summary>
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

        /// <summary>
        /// inverted level backing field
        /// </summary>
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

        /// <summary>
        /// label backing field
        /// </summary>
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

        /// <summary>
        /// label width backing field
        /// </summary>
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

        /// <inheritdoc/>
        public abstract void HandleTick();

        /// <inheritdoc/>
        protected void Reset() => Level = 0;

        /// <inheritdoc/>
        public void Start() => Reset();

        /// <inheritdoc/>
        public void Stop() => Reset();

    }
}
