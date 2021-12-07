﻿
using WindowsAudioSession.Components.AudioCapture;

using WPFUtilities.ComponentModel;

namespace WindowsAudioSession.UI.FFT
{
    public interface IFFTViewModel : IModelBase, IModelDataValidation, IAudioPlugHandler
    {
        int BarCount { get; set; }

        int BarWidthPercent { get; set; }

    }
}
