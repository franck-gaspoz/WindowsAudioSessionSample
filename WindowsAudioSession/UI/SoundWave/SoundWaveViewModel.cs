using System.Windows;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundWave
{
    public class SoundWaveViewModel : ModelBase, ISoundWaveViewModel
    {
        Thickness _drawMargin = new Thickness(8);

        /// <summary>
        /// draw margin
        /// </summary>
        public Thickness DrawMargin
        {
            get => _drawMargin;

            set
            {
                _drawMargin = value;
                NotifyPropertyChanged();
            }
        }
    }
}
