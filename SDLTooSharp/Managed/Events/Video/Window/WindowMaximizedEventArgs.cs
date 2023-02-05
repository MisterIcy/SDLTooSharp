using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Maximized"/>
/// </summary>
public class WindowMaximizedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowMaximizedEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowMaximizedEventArgs(IWindow window) : base(window)
    {
    }
}
