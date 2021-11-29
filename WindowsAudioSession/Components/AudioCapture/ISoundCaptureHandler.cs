namespace WindowsAudioSession.Components.AudioCapture
{
    public interface ISoundCaptureHandler
    {
        void HandleTick();

        void Start();

        void Stop();
    }
}
