using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Video.Surface;

namespace SDLTooSharp.Managed.Font;

public interface IFont
{
    public ISurface RenderGlyphLCD(uint glyph, Color foreground, Color background);
}
