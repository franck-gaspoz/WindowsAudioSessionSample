
using System;

using Un4seen.Bass;

namespace WASApiBassNet.Components.FFT
{
    /// <summary>
    /// fft length extensions
    /// </summary>
    public static class FFTLengthExtensions
    {
        /// <summary>
        /// convert fft length to buffer size
        /// </summary>
        /// <param name="fftLength">fft length</param>
        /// <returns>buffer size</returns>
        public static int ToBufferSize(this FFTLength fftLength)
            => Convert.ToInt32(fftLength.ToString().Replace("FFT", ""));

        /// <summary>
        /// converts a fft length to a bass data value        
        /// </summary>
        /// <exception cref="ArgumentException">value is not convertible</exception>
        /// <param name="fftLength">fft length</param>
        /// <returns>bass data</returns>
        public static BASSData ToBassData(this FFTLength fftLength)
        {
            return Enum.TryParse<BASSData>("BASS_DATA_" + fftLength.ToString(), out var bassData)
                ? bassData
                : throw ExceptionHelper.BuildException(
                    new ArgumentException($"SampleLength {fftLength} has no correspondancy in BassData", nameof(fftLength)));
        }

        /// <summary>
        /// converts an int size to a fft length
        /// </summary>
        /// <exception cref="ArgumentException">value is not convertible</exception>
        /// <param name="fftLength">fft length as an int</param>
        /// <returns>fft length</returns>
        public static FFTLength ToSampleLength(this int fftLength)
        {
            return Enum.TryParse<FFTLength>("FFT" + fftLength, out var sampleLengthEnum)
                ? sampleLengthEnum
                : throw ExceptionHelper.BuildException(
                    new ArgumentException($"int {fftLength} has no correspondancy in enum SampleLength", nameof(fftLength)));
        }
    }
}
