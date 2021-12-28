using WindowsAudioSession.Components.AudioCapture;
using WindowsAudioSession.UI;

namespace WindowsAudioSession
{
    public interface IAppComponents
    {
        void BuildComponents(IWASMainViewModel viewModel);

        IAudioPlugEngine AudioPlugEngine { get; }
    }
}