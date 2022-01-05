using System.Collections.Generic;
using System.ComponentModel;

using Un4seen.BassWasapi;

namespace WindowsAudioSession.UI
{
    /// <summary>
    /// main view model
    /// </summary>
    public interface IWASMainViewModel
    {
        /// <summary>
        /// indicates if the audio engine interactor can be started or not
        /// </summary>
        bool CanStart { get; set; }

        /// <summary>
        /// fft resolution
        /// </summary>
        int FFTResolution { get; set; }

        /// <summary>
        /// available fft resolutions
        /// </summary>
        List<int> FFTResolutions { get; }

        /// <summary>
        /// indicates if the audio engine interactor is started or not
        /// </summary>
        bool IsStarted { get; set; }

        /// <summary>
        /// indicates if the main window is topmost
        /// </summary>
        bool IsTopmost { get; set; }

        /// <summary>
        /// list of availble sound devices
        /// </summary>
        BindingList<BASS_WASAPI_DEVICEINFO> ListenableDevices { get; }

        /// <summary>
        /// list of available sample frequencies
        /// </summary>
        List<int> SampleFrequencies { get; }

        /// <summary>
        /// sample frequency
        /// </summary>
        int SampleFrequency { get; set; }

        /// <summary>
        /// sample length
        /// </summary>
        int SampleLength { get; set; }

        /// <summary>
        /// available sample lengths
        /// </summary>
        List<int> SampleLengths { get; }

        /// <summary>
        /// selected sound device (BassNet)
        /// </summary>
        BASS_WASAPI_DEVICEINFO SelectedDevice { get; set; }
    }
}