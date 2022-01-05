using System.Windows.Media;

using WASApiBassNet.Components.AudioCapture;
using WASApiBassNet.Components.Sample;

namespace WindowsAudioSession.UI.SoundWave
{
    public interface ISoundWaveDrawer : IAudioPlugin
    {
        /// <summary>
        /// drawable control
        /// </summary>
        IDrawable Drawable { get; set; }

        /// <summary>
        /// sound sample provider
        /// </summary>
        ISoundSampleProvider SoundSampleProvider { get; set; }

        /// <summary>
        /// indicates if the drawer is started or not
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// margin
        /// </summary>
        double Margin { get; set; }

        /// <summary>
        /// resolution
        /// </summary>
        double Resolution { get; set; }

        /// <summary>
        /// line brush
        /// </summary>
        Brush LineBrush { get; set; }

        /// <summary>
        /// scale factor
        /// </summary>
        double ScaleFactor { get; set; }
    }
}
