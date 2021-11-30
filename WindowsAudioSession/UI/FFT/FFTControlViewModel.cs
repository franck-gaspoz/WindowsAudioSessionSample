
using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.Components.FFT;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.FFT
{
    public class FFTControlViewModel : ModelBase, ISoundCaptureHandler
    {
        readonly FFTDrawer _fftDrawer;

        public FFTControlViewModel(FFTControl fftControl)
        {
            _fftDrawer = new FFTDrawer(fftControl.BarGraph);
        }

        public void AttachTo(FFTAnalyzer fftAnalyzer)
        {
            _fftDrawer.AttachTo(fftAnalyzer);
        }

        public void HandleTick()
        {
            _fftDrawer.HandleTick();
        }

        public void Start()
        {
            _fftDrawer.Start();
        }

        public void Stop()
        {
            _fftDrawer.Stop();
        }
    }
}
