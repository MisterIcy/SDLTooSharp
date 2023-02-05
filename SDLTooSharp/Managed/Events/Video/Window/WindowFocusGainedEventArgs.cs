using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.FocusGained"/> event.
/// </summary>
public class WindowFocusGainedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowFocusGainedEventArgs"/>.
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowFocusGainedEventArgs(IWindow window) : base(window)
    {
    }
}
