using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI
{
    public class WASOverviewWindowViewModel : ModelBase
    {
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

        int _fftResolution = 8192;

        /// <summary>
        /// fft resolution
        /// </summary>
        public int FFTResolution
        {
            get
            {
                return _fftResolution;
            }
            set
            {
                _fftResolution = value;
                NotifyPropertyChanged();
            }
        }

        public List<int> FFTResolutions { get; protected set; } = new List<int>
        {
            1024,2048,4096,8192,16384
        };

        int _sampleFrequency = 41000;

        /// <summary>
        /// sample frequency
        /// </summary>
        public int SampleFrequency
        {
            get => _sampleFrequency;
            set
            {
                _sampleFrequency = value;
                NotifyPropertyChanged();
            }
        }

        public List<int> SampleFrequencies { get; protected set; } = new List<int>
        {
            41000,
            48000
        };

        int _sampleLength = 16384;

        /// <summary>
        /// sample length
        /// </summary>
        public int SampleLength
        {
            get => _sampleLength;

            set
            {
                _sampleLength = value;
                NotifyPropertyChanged();
            }
        }

        public List<int> SampleLengths { get; protected set; } = new List<int>
        {
            128,
            256,
            512,
            1024,
            2048,
            4096,
            8192,
            16384,
            32768,
            65536
        };

        public WASOverviewWindowViewModel()
        {
            var devices = new ListenableSoundDevices().DevicesList;
            foreach (var device in devices)
                ListenableDevices.Add(device);
        }
    }
}
