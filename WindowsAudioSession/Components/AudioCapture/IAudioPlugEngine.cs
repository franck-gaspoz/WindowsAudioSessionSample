namespace WindowsAudioSession.Components.AudioCapture
{
    public interface IAudioPlugEngine
    {
        ListenableSoundDevices ListenabledSoundDevices { get; }
        IWASApi WASApi { get; set; }

        AudioPlugEngine AddAudioPlugHandler(IAudioPlugHandler soundCaptureHandler);
        AudioPlugEngine RemoveAudioPlugHandler(IAudioPlugHandler soundCaptureHandler);
        void Reset();
        void Start(int soundDeviceIndex, int sampleRate = 44100);
        void Stop();
    }
}