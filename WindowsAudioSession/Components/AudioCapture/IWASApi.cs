namespace WindowsAudioSession.Components.AudioCapture
{
    public interface IWASApi
    {
        void InitiliazeSoundCapture(int soundDeviceIndex, int sampleRate);
        void StopWasapiCapture();
    }
}