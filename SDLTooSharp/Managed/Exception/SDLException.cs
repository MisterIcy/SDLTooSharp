using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Exception;

public abstract class SDLException : System.Exception
{
    /// <summary>
    /// Gets the error message reported by SDL
    /// </summary>
    public string SdlErrorMsg { get; }
    protected SDLException(string message) : base(message)
    {
        SdlErrorMsg = SDL.SDL_GetError();
    }
}
