using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Exposed"/> event
/// </summary>
public class WindowExposedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowExposedEventArgs"/>.
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowExposedEventArgs(IWindow window) : base(window)
    {
    }
}
