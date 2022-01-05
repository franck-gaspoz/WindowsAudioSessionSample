
using Un4seen.Bass;
using Un4seen.BassWasapi;

using WASApiBassNet.Components.AudioCapture;

namespace WASApiBassNet.Components.Sample
{
    /// <summary>
    /// sound sample data provider
    /// </summary>
    public class SoundSampleProvider : ISoundSampleProvider, IAudioPlugin
    {
        int _bufferLength;
        /// <inheritdoc/>
        public int BufferLength
        {
            get => _bufferLength;
            set
            {
                _bufferLength = value;
                SoundSampleData = new float[_bufferLength];
            }
        }

        /// <inheritdoc/>
        public float[] SoundSampleData { get; protected set; }

        /// <inheritdoc/>
        public bool IsDataAvailable { get; protected set; }

        /// <inheritdoc/>
        public int AvailableLength { get; protected set; }

        /// <inheritdoc/>
        public void HandleTick()
        {
            var previewAvailableLength = BassWasapi.BASS_WASAPI_GetData(
                SoundSampleData,
                (int)BASSData.BASS_DATA_AVAILABLE
                );

            if (previewAvailableLength > 0)
            {
                AvailableLength = BassWasapi.BASS_WASAPI_GetData(
                    SoundSampleData,
                    SoundSampleData.Length
                );
                if (AvailableLength > 0)
                    AvailableLength /= 4;
                IsDataAvailable = AvailableLength > 0;
            }
        }

        /// <inheritdoc/>
        public void Start()
        {
        }

        /// <inheritdoc/>
        public void Stop()
        {
            IsDataAvailable = false;
            AvailableLength = 0;
        }
    }
}
