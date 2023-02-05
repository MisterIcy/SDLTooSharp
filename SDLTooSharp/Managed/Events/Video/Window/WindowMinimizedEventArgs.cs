using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Minimized"/>
/// </summary>
public class WindowMinimizedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowMinimizedEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowMinimizedEventArgs(IWindow window) : base(window)
    {
    }
}
