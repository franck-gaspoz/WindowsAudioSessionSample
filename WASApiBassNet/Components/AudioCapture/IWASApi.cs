namespace WASApiBassNet.Components.AudioCapture
{
    /// <summary>
    /// wasapi facade
    /// </summary>
    public interface IWASApi
    {
        /// <summary>
        /// intiatize the wasapi sound capture
        /// </summary>
        /// <param name="soundDeviceIndex">sound device index</param>
        /// <param name="sampleRate">capture sample rate</param>
        void InitiliazeSoundCapture(int soundDeviceIndex, int sampleRate);

        /// <summary>
        /// stops the wasapi capture
        /// </summary>
        void StopWasapiCapture();
    }
}