using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Events.Video.Window;

/// <summary>
/// Basis for all Window-related EventArgs
/// </summary>
public abstract class AbstractWindowEventArgs : EventArgs
{
    /// <summary>
    /// The <see cref="IWindow"/> for which the event was triggered.
    /// </summary>
    public IWindow Window { get; }

    /// <summary>
    /// Creates a new <see cref="AbstractWindowEventArgs"/>.
    /// </summary>
    /// <param name="window">The <see cref="IWindow"/> for which the event was triggered</param>
    protected AbstractWindowEventArgs(IWindow window)
    {
        Window = window;
    }
}
