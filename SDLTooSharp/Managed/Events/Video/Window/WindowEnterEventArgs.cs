using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs Class for the <see cref="IWindow.Enter"/> event
/// </summary>
public class WindowEnterEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowEnterEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowEnterEventArgs(IWindow window) : base(window)
    {
    }
}
