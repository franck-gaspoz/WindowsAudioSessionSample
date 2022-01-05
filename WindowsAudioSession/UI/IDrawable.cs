using System.Windows.Controls;

namespace WindowsAudioSession.UI
{
    /// <summary>
    /// drawable control interface
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// indicates the drawing surface as a Canvas
        /// </summary>
        /// <returns>canvas where to draw</returns>
        Canvas GetDrawingSurface();
    }
}
