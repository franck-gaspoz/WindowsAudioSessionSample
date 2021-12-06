namespace WindowsAudioSession.Components.FFT
{
    public interface IFFTPeakAnalyzer
    {
        double[] SpectrumPeakData { get; }

        double DecayStep { get; set; }
    }
}
