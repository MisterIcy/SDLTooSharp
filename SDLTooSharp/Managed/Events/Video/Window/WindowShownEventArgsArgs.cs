using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs Class for <see cref="IWindow.Shown"/> event.
/// </summary>
public class WindowShownEventArgsArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowShownEventArgsArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowShownEventArgsArgs(IWindow window) : base(window)
    {
    }
}
