
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

        string _channelLabel = "?";

        /// <summary>
        /// channel label
        /// </summary>
        public string ChannelLabel
        {
            get
            {
                return _channelLabel;
            }
            set
            {
                _channelLabel = value;
                NotifyPropertyChanged();
            }
        }
    }
}