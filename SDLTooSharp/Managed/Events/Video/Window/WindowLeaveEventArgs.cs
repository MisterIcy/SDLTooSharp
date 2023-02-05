using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Leave"/> event.
/// </summary>
public class WindowLeaveEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowLeaveEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowLeaveEventArgs(IWindow window) : base(window)
    {
    }
}
