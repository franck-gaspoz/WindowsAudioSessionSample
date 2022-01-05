using WASApiBassNet.Components.AudioCapture;
using WASApiBassNet.Components.SoundLevel;

namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// vumeter view model
    /// </summary>
    public interface IVuMeterViewModel : IAudioPlugin
    {
        /// <summary>
        /// level scale factor
        /// </summary>
        double LevelScaleFactor { get; set; }

        /// <summary>
        /// sound level capture data provider
        /// </summary>
        ISoundLevelCapture SoundLevelCapture { get; set; }

        /// <summary>
        /// sound level
        /// </summary>
        double Level { get; set; }

        /// <summary>
        /// sound inverted level
        /// </summary>
        double InvertedLevel { get; set; }

        /// <summary>
        /// vumeter label
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// vumeter label width
        /// </summary>
        double LabelWidth { get; set; }
    }
}
