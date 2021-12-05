
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace WindowsAudioSession.Components.AudioCapture
{
    public class SoundSampleProvider : ISoundCaptureHandler
    {
        public float[] SoundSampleData;

        public bool IsDataAvailable { get; protected set; }

        public int AvailableLength { get; protected set; }

        public SoundSampleProvider(int bufferLength)
        {
            SoundSampleData = new float[bufferLength];
        }

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
