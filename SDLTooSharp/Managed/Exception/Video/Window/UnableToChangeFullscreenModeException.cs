using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Exception.Video.Window;

/// <summary>
/// Thrown when we cannot change the fullscreen mode of the window
/// </summary>
public sealed class UnableToChangeFullscreenModeException : WindowException
{
    /// <summary>
    /// Creates a new <see cref="UnableToChangeFullscreenModeException"/>
    /// </summary>
    /// <param name="mode">The fullscreen mode we attempted to change to.</param>
    public UnableToChangeFullscreenModeException(
        WindowMode mode) : base($"Unable to change the window's fullscreen mode to {mode.ToString()}")
    {
    }
}
