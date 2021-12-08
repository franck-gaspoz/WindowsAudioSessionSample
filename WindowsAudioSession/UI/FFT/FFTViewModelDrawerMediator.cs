using System.ComponentModel;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// mediate properties changes from IFFTViewModel for IFFTDrawer
    /// </summary>
    public class FFTViewModelDrawerMediator
    {
        IFFTViewModel _fftViewModel;
        IFFTDrawer _fftDrawer;

        public void InitializeMediate(IFFTViewModel fftViewModel, IFFTDrawer fftDrawer)
        {
            ClearMediate();
            _fftViewModel = fftViewModel;
            _fftDrawer = fftDrawer;
            _fftViewModel.PropertyChanged += FFTViewModel_PropertyChanged;
        }

        public void ClearMediate()
        {
            if (_fftViewModel != null)
                _fftViewModel.PropertyChanged -= FFTViewModel_PropertyChanged;
            _fftViewModel = null;
            _fftDrawer = null;
        }

        private void FFTViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IFFTDrawer.BarWidthPercent))
                _fftDrawer.BarWidthPercent = _fftViewModel.BarWidthPercent;
        }
    }
}
