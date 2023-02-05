using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Exception;

/// <summary>
/// Base exception for all SDL-Related issues.
/// </summary>
public abstract class SDLException : System.Exception
{
    /// <summary>
    /// Gets the error message reported by SDL.
    /// </summary>
    public string SdlErrorMsg { get; }

    /// <summary>
    /// Creates a new SDLException
    /// </summary>
    /// <param name="message">The message that describes the error</param>
    /// <remarks>In case we cannot call <see cref="SDL.SDL_GetError"/> to obtain the error message from
    /// SDL, a generic <i>Unable to find the SDL library</i> error will be set in <see cref="SdlErrorMsg"/></remarks>
    protected SDLException(string message) : base(message)
    {
        try
        {
            SdlErrorMsg = SDL.SDL_GetError();
        } catch ( DllNotFoundException )
        {
            // In case the application cannot find the SDL Library:
            SdlErrorMsg = "Unable to find the SDL library";
        }
    }
}
