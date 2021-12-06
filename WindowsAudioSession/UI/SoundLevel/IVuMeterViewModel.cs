namespace WindowsAudioSession.UI.SoundLevel
{
    public interface IVuMeterViewModel
    {
        double Level { get; set; }

        double InvertedLevel { get; set; }

        string Label { get; set; }

        double LabelWidth { get; set; }
    }
}
