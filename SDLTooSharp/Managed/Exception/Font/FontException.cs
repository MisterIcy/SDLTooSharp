using SDLTooSharp.Bindings.SDL2Ttf;

namespace SDLTooSharp.Managed.Exception.Font;

public class FontException : SDLException
{
    public string TTFError { get; protected set; }

    public FontException(string message) : base(message)
    {
        TTFError = SDLTtf.TTF_GetError();
    }

    public static FontException UnableToOpen(string filename)
    {
        return new FontException($"Unable to open the font ${filename}.");
    }

    public static FontException UnableToRenderText()
    {
        return new FontException("Unable to render text.");
    }
}
