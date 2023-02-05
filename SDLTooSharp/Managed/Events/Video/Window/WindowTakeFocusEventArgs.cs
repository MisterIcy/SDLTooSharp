using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.TakeFocus"/>
/// </summary>
public class WindowTakeFocusEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new <see cref="WindowTakeFocusEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered</param>
    public WindowTakeFocusEventArgs(IWindow window) : base(window)
    {
    }
}
