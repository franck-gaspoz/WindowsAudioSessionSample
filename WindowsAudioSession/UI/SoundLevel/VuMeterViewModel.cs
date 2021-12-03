
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
            }
        }

        string _label = "?";

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
            get
            {
                return _labelWidth;
            }
            set
            {
                _labelWidth = value;
                NotifyPropertyChanged();
            }
        }
    }
}