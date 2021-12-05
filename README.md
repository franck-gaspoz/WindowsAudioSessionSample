# Windows Audio Session (WASAPI) sample

A sample of usage of Windows Audio Session WASAPI using BASS.NET - WPF C# .NET Framework 4.8

- colored bars (vu-meters) showing captured device sound FFT , Sound Level and sound wave

Clean architecture approach: complete discoupling between data,data providers,data transformers,ui controls,drawers,view models,application logic. Relying on the patterns MVVM, Command and Chain of responsability. Implements several importants aspects of WPF programming:
- User Controls
- Resources/Styles
- Converters
- View Models
- Data annotations
- Data validators
- Data binding
- Commands

<p align="center">
<img src="https://github.com/franck-gaspoz/WindowsAudioSessionSample/blob/36c820172839adf880d6864784d9bb0e2f2d9575/Doc/windows-audio-session-sample3.gif" width="70%" align="center" style="margin-left:auto;margin-right:auto" alt="a FFT having 512 bars + FFT with 16 bars and peak bars + stereo sound level">
<br>
<i>a FFT having 512 bars + FFT with 16 bars and peak bars + stereo sound level + sound wave</i>
</p>

Run the project, select your audio device, and this tool will listen to the device internal output and animates some of the sound properties. The library BASS.NET is used to interface C# with the WASAPI Windows library.
