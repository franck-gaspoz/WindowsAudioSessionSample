
using Un4seen.Bass;
using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.Sample
{
    public class SoundSampleProvider : ISoundSampleProvider, IAudioPlugHandler
    {
        int _bufferLength;
        public int BufferLength
        {
            get => _bufferLength;
            set
            {
                _bufferLength = value;
                SoundSampleData = new float[_bufferLength];
            }
        }

        public float[] SoundSampleData { get; protected set; }

        public bool IsDataAvailable { get; protected set; }

        public int AvailableLength { get; protected set; }

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

        public void Start()
        {
        }

        public void Stop()
        {
            IsDataAvailable = false;
            AvailableLength = 0;
        }
    }
}
