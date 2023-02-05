using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Close"/>
/// </summary>
public class WindowCloseEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowCloseEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered</param>
    public WindowCloseEventArgs(IWindow window) : base(window)
    {
    }
}
