using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// EventArgs class for <see cref="IWindow.DisplayChanged"/>
/// </summary>
public class WindowDisplayChangedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// The ID of the Display where the window was moved.
    /// </summary>
    /// <remarks>TODO: Change this with a display object when implemented</remarks>
    public uint DisplayId { get; }

    /// <summary>
    /// Creates a new <see cref="WindowDisplayChangedEventArgs"/>
    /// </summary>
    /// <param name="window">The window for which the event was triggered</param>
    public WindowDisplayChangedEventArgs(IWindow window, uint displayId) : base(window)
    {
        DisplayId = displayId;
    }
}
