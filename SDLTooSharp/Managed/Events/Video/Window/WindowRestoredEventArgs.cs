using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Restored"/> event
/// </summary>
public class WindowRestoredEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowRestoredEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered</param>
    public WindowRestoredEventArgs(IWindow window) : base(window)
    {
    }
}
