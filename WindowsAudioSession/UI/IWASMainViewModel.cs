using System.Collections.Generic;
using System.ComponentModel;

using Un4seen.BassWasapi;

namespace WindowsAudioSession.UI
{
    public interface IWASMainViewModel
    {
        bool CanStart { get; set; }
        int FFTResolution { get; set; }
        List<int> FFTResolutions { get; }
        bool IsStarted { get; set; }
        bool IsTopmost { get; set; }
        BindingList<BASS_WASAPI_DEVICEINFO> ListenableDevices { get; }
        List<int> SampleFrequencies { get; }
        int SampleFrequency { get; set; }
        int SampleLength { get; set; }
        List<int> SampleLengths { get; }
        BASS_WASAPI_DEVICEINFO SelectedDevice { get; set; }
    }
}