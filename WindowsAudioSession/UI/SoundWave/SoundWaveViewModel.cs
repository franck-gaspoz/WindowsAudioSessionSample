using System.Windows;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.SoundWave
{
    /// <summary>
    /// sound wave view mdoel
    /// </summary>
    public class SoundWaveViewModel : ModelBase, IModelBase, ISoundWaveViewModel
    {
        /// <summary>
        /// draw margin backing field
        /// </summary>
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
