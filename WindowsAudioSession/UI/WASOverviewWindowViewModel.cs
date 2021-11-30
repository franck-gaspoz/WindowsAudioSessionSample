using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;

using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI
{
    public class WASOverviewWindowViewModel : ModelBase
    {
        int _barCount = 512;
        /// <summary>
        /// bar count
        /// </summary>
        [Range(1, 5)]
        public int BarCount
        {
            get
            {
                return _barCount;
            }
            set
            {
                _barCount = value;
                NotifyPropertyChanged();
            }
        }

        public BindingList<BASS_WASAPI_DEVICEINFO> ListenableDevices { get; protected set; } = new BindingList<BASS_WASAPI_DEVICEINFO>();

        BASS_WASAPI_DEVICEINFO _selectedDevice = null;

        /// <summary>
        /// selected device
        /// </summary>
        public BASS_WASAPI_DEVICEINFO SelectedDevice
        {
            get => _selectedDevice;

            set
            {
                _selectedDevice = value;
                NotifyPropertyChanged();
                CanStart = !IsStarted && _selectedDevice != null;
            }
        }

        bool _isStarted = false;
        /// <summary>
        /// is started
        /// </summary>
        public bool IsStarted
        {
            get => _isStarted;

            set
            {
                _isStarted = value;
                CanStart = false;
                NotifyPropertyChanged();
            }
        }

        bool _canStart = false;
        /// <summary>
        /// can start
        /// </summary>
        public bool CanStart
        {
            get => _canStart;

            set
            {
                _canStart = value;
                NotifyPropertyChanged();
            }
        }

        bool _isTopmost = true;
        /// <summary>
        /// window is topmost
        /// </summary>
        public bool IsTopmost
        {
            get => _isTopmost;
            set
            {
                _isTopmost = value;
                Application.Current.MainWindow.Topmost = value;
                NotifyPropertyChanged();
            }
        }

        public WASOverviewWindowViewModel()
        {
            var devices = new ListenableSoundDevices().DevicesList;
            foreach (var device in devices)
                ListenableDevices.Add(device);
        }
    }
}
