
using System;

using Un4seen.Bass;

namespace WindowsAudioSession.Components.FFT
{
    public static class FFTLengthExt
    {
        public static int ToBufferSize(this FFTLength fftLength)
            => Convert.ToInt32(fftLength.ToString().Replace("FFT", ""));

        public static BASSData ToBassData(this FFTLength fftLength)
        {
            return Enum.TryParse<BASSData>("BASS_DATA_" + fftLength.ToString(), out var bassData)
                ? bassData
                : throw ExceptionHelper.BuildException(
                    new ArgumentException($"SampleLength {fftLength} has no correspondancy in BassData", nameof(fftLength)));
        }

        public static FFTLength ToSampleLength(this int fftLength)
        {
            return Enum.TryParse<FFTLength>("FFT" + fftLength, out var sampleLengthEnum)
                ? sampleLengthEnum
                : throw ExceptionHelper.BuildException(
                    new ArgumentException($"int {fftLength} has no correspondancy in enum SampleLength", nameof(fftLength)));
        }
    }
}
