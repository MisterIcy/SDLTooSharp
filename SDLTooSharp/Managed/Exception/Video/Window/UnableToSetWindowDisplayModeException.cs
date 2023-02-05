using SDLTooSharp.Managed.Video;
using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Exception.Video.Window;

/// <summary>
/// Thrown when we are not able to change the <see cref="SDLWindow"/>'s <see cref="DisplayMode"/>.
/// </summary>
/// <remarks></remarks>
public sealed class UnableToSetWindowDisplayModeException : WindowException
{
    public UnableToSetWindowDisplayModeException() : base("Unable to set the Window's display mode")
    {
    }
}
