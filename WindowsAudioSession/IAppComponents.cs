using WASApiBassNet.Components.AudioCapture;

using WindowsAudioSession.UI;

namespace WindowsAudioSession
{
    /// <summary>
    /// Application components
    /// </summary>
    public interface IAppComponents
    {
        /// <summary>
        /// build application components and setup components dependencies
        /// </summary>
        /// <param name="viewModel"></param>
        void BuildComponents(IWASMainViewModel viewModel);

        /// <summary>
        /// audio plugin engine interactor
        /// </summary>
        IAudioPluginEngine AudioPluginEngine { get; }
    }
}