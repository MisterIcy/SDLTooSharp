using SDLTooSharp.Managed.Video;
using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Exception.Video.Window;

/// <summary>
/// Thrown when we are not able to acquire the <see cref="DisplayMode"/> of the <see cref="SDLWindow"/>
/// </summary>
public sealed class UnableToGetWindowDisplayModeException : WindowException
{
    /// <summary>
    /// Creates a new <see cref="UnableToGetWindowDisplayModeException"/>
    /// </summary>
    public UnableToGetWindowDisplayModeException() : base("Unable to get the Window's display mode")
    {
    }
}
