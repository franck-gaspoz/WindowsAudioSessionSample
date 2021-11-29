using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using Un4seen.BassWasapi;

using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;
using WindowsAudioSession.UI.FFT;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI
{
    public class WASOverviewWindowViewModel : ModelBase
    {
        FFTAnalyzer _fftAnalyser;
        SoundListener _soundListener;
        FFTDrawer _fftDrawer;
        readonly Canvas _canvas;

        int _barCount = 512;
        /// <summary>
        /// bar count
        /// </summary>
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

        //public BASS_WASAPI_DEVICEINFO SelectedDevice { get; set; }

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

        public WASOverviewWindowViewModel(Canvas canvas)
        {
            _canvas = canvas;

            var devices = new ListenableSoundDevices().DevicesList;
            foreach (var device in devices)
                ListenableDevices.Add(device);
        }

        internal void Start()
        {
            _soundListener = new SoundListener();
            _fftAnalyser = new FFTAnalyzer(SampleLength.FFT1024, BarCount);

            _fftDrawer = new FFTDrawer(_canvas, _fftAnalyser);

            _ = _soundListener
                .AddSoundCaptureHandler(_fftAnalyser)
                .AddSoundCaptureHandler(_fftDrawer);

            var deviceId = Convert.ToInt32(SelectedDevice.id);

            _soundListener.Start(deviceId);

            IsStarted = true;
        }

        internal void Stop()
        {
            _soundListener.Stop();

            IsStarted = false;
            CanStart = true;
        }
    }
}
