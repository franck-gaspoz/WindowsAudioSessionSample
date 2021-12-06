namespace WindowsAudioSession.Components.AudioCapture
{
    /// <summary>
    /// rename to IAudioPlug
    /// </summary>
    public interface ISoundCaptureHandler
    {
        void HandleTick();

        void Start();

        void Stop();
    }
}
