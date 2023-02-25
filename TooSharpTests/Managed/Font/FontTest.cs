using System.Diagnostics.CodeAnalysis;
using Moq;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Font;
using SDLTooSharp.Managed.Video.Surface;

namespace TooSharpTests.Managed.Font;

[ExcludeFromCodeCoverage]
public class FontTest
{
    [Fact]
    public void TestRenderGlyphLCD()
    {
        uint glyph = 1;
        Color fg = new Color(0, 0, 0);
        Color bg = new Color(0, 0, 0);

        var surface = new SDLSurface(
            new Size(1, 1),
            SurfaceDepth.Depth32BitPerPixel,
            SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA8888
        );

        var mock = new Mock<IFont>();
        mock.Setup(x => x.RenderGlyphLCD(glyph, fg, bg)).Returns(surface);

        Assert.Equal(surface, mock.Object.RenderGlyphLCD(glyph, fg, bg));
    }
}
