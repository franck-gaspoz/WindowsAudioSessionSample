
using Un4seen.Bass;

namespace WindowsAudioSession.Components.FFT
{
    public static class SampleLengthExt
    {
        public static int ToBufferSize(this SampleLength sampleLength)
        {
            switch (sampleLength)
            {
                case SampleLength.FFT1024: return 1024;
                default: return 1024;
            }
        }

        public static BASSData ToBassData(this SampleLength sampleLength)
        {
            switch (sampleLength)
            {
                case SampleLength.FFT1024: return BASSData.BASS_DATA_FFT2048;
                default: return BASSData.BASS_DATA_FFT2048;
            }
        }
    }
}
