﻿namespace WindowsAudioSession.Components.AudioCapture
{
    /// <summary>
    /// rename to IAudioPlug
    /// </summary>
    public interface IAudioPlugHandler
    {
        void HandleTick();

        void Start();

        void Stop();
    }
}