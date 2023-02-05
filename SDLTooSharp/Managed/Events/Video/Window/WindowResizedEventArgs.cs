using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.Resized"/>
/// </summary>
public class WindowResizedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// The new <see cref="IWindow.Size"/> of the <see cref="IWindow"/>
    /// </summary>
    public Size Dimensions { get; }

    /// <summary>
    /// Creates a new <see cref="WindowResizedEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered.</param>
    /// <param name="dimensions">The new dimensions of the <see cref="IWindow"/></param>
    public WindowResizedEventArgs(IWindow window, Size dimensions) : base(window)
    {
        Dimensions = dimensions;
    }
}
