using System.Collections.Generic;

using Un4seen.BassWasapi;

namespace WASApiBassNet.Components.AudioCapture
{
    /// <summary>
    /// listenables sound devices model
    /// </summary>
    public class ListenableSoundDevices
    {
        /// <summary>
        /// available sound devices
        /// </summary>
        public List<BASS_WASAPI_DEVICEINFO> DevicesList { get; }
            = new List<BASS_WASAPI_DEVICEINFO>();

        /// <summary>
        /// creates a new model
        /// </summary>
        public ListenableSoundDevices()
        {
            for (var i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
            {
                var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                device.id = i + "";
                if (device.IsEnabled && device.IsLoopback)
                {
                    DevicesList.Add(device);
                }
            }
        }
    }
}