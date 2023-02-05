using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Moved"/> event.
/// </summary>
public class WindowMovedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// The new <see cref="IWindow.Position"/> of the <see cref="IWindow"/>
    /// </summary>
    public Point2 Position { get; }

    /// <summary>
    /// Creates a new <see cref="WindowMovedEventArgs"/>.
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    /// <param name="position">The new position of the <see cref="IWindow"/></param>
    public WindowMovedEventArgs(IWindow window, Point2 position) : base(window)
    {
        Position = position;
    }
}
