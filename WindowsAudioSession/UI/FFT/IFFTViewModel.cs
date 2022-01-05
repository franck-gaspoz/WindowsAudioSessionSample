
using WASApiBassNet.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// fft view model
    /// </summary>
    public interface IFFTViewModel : IModelBase, IValidableModel, IAudioPlugin
    {
        /// <summary>
        /// bar count
        /// </summary>
        int BarCount { get; set; }

        /// <summary>
        /// bar width percent
        /// </summary>
        int BarWidthPercent { get; set; }

    }
}
