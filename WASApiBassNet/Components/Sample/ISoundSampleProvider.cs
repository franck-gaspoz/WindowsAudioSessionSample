
using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.Sample
{
    /// <summary>
    /// sound sample data provider
    /// </summary>
    public interface ISoundSampleProvider : IAudioPlugin
    {
        /// <summary>
        /// sound buffer length
        /// </summary>
        int BufferLength { get; set; }

        /// <summary>
        /// sound sample data output
        /// </summary>
        float[] SoundSampleData { get; }

        /// <summary>
        /// indicates if any output data is available
        /// </summary>
        bool IsDataAvailable { get; }

        /// <summary>
        /// indicates the real size of available output data
        /// </summary>
        int AvailableLength { get; }
    }
}
