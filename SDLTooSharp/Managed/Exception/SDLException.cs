using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Exception;

public abstract class SDLException : System.Exception
{
    /// <summary>
    /// Gets the error message reported by SDL.
    /// </summary>
    public string SdlErrorMsg { get; }

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
