using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.FocusLost"/> event
/// </summary>
public class WindowFocusLostEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowFocusLostEventArgs"/>.
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowFocusLostEventArgs(IWindow window) : base(window)
    {
    }
}
