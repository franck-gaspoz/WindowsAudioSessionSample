namespace WindowsAudioSession.UI.SoundLevel
{
    /// <summary>
    /// stereo view meter view model
    /// </summary>
    public interface IVuMeterStereoViewModel
    {
        /// <summary>
        /// vumeter left channel view model
        /// </summary>
        IVuMeterViewModel VuMeterLeftViewModel { get; }

        /// <summary>
        /// vumeter right channel view model
        /// </summary>
        IVuMeterViewModel VuMeterRightViewModel { get; }

    }
}
