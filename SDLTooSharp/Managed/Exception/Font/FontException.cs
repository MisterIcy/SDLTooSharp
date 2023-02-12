using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Bindings.SDL2Ttf;

namespace SDLTooSharp.Managed.Exception.Font;

public class FontException : SDLException
{

    public FontException(string message) : base(message)
    {
    }

    public static FontException UnableToOpen(string filename)
    {
        return new FontException($"Unable to open the font {filename} ({SDL.SDL_GetError()}).");
    }

    public static FontException UnableToRenderText()
    {
        return new FontException("Unable to render text.");
    }
}
