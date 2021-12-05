
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace WindowsAudioSession.Components.AudioCapture
{
    public class SoundSampleProvider : ISoundCaptureHandler
    {
        public float[] SoundSample { get; protected set; }

        public bool IsDataAvailable { get; protected set; }

        public int AvailableLength { get; protected set; }

        public SoundSampleProvider(int bufferLength)
        {
            SoundSample = new float[bufferLength];
        }

        public void HandleTick()
        {
            var previewAvailableLength = BassWasapi.BASS_WASAPI_GetData(
                SoundSample,
                (int)BASSData.BASS_DATA_AVAILABLE
                );

            if (previewAvailableLength > 0)
            {
                var AvailableLength = BassWasapi.BASS_WASAPI_GetData(
                SoundSample,
                SoundSample.Length
                );
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
