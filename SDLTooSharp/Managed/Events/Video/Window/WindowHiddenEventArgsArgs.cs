using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Hidden"/> event.
/// </summary>
public class WindowHiddenEventArgsArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowHiddenEventArgsArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    public WindowHiddenEventArgsArgs(IWindow window) : base(window)
    {
    }
}
