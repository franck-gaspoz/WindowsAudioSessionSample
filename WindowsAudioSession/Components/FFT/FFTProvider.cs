
using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;

namespace WindowsAudioSession.Components.FFT
{
    public class FFTProvider : ISoundCaptureHandler
    {
        public float[] FFT { get; protected set; }

        public SampleLength SampleLength { get; protected set; }

        public bool IsFFTAvailable { get; protected set; } = true;

        public FFTProvider(SampleLength sampleLength)
        {
            SampleLength = sampleLength;
            FFT = new float[sampleLength.ToBufferSize()];
        }

        public void HandleTick()
        {
            var ret = BassWasapi.BASS_WASAPI_GetData(
                FFT,
                (int)SampleLength.ToBassData());
            IsFFTAvailable = ret >= -1;
        }

        public void Start() { }

        public void Stop()
        {
            IsFFTAvailable = false;
        }
    }
}
