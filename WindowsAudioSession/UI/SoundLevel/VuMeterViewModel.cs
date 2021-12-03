
using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundLevel
{
    public class VuMeterViewModel : ModelBase
    {
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
            get
            {
                return _invertedLevel;
            }
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
            get
            {
                return _label;
            }
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

    }
}