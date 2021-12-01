
using System;

using Un4seen.Bass;

namespace WindowsAudioSession.Components.FFT
{
    public static class SampleLengthExt
    {
        public static int ToBufferSize(this SampleLength sampleLength)
            => Convert.ToInt32(sampleLength.ToString().Replace("FFT", ""));

        public static BASSData ToBassData(this SampleLength sampleLength)
        {
            return Enum.TryParse<BASSData>("BASS_DATA_FFT" + sampleLength.ToString(), out var bassData)
                ? bassData
                : throw ExceptionHelper.BuildException(
                    new ArgumentException($"SampleLength {sampleLength} has no correspondancy in BassData", nameof(sampleLength)));
        }

        public static SampleLength ToSampleLength(this int sampleLength)
        {
            return Enum.TryParse<SampleLength>("FFT" + sampleLength, out var sampleLengthEnum)
                ? sampleLengthEnum
                : throw ExceptionHelper.BuildException(
                    new ArgumentException($"int {sampleLength} has no correspondancy in enum SampleLength", nameof(sampleLength)));
        }
    }
}
