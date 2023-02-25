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

        var mock = new Mock<IFont>();
        mock.Setup(x => x.RenderGlyphLCD(glyph, fg, bg))
            .Returns(() => {
                var srf = new SDLSurface(
                    new Size(1, 2),
                    SurfaceDepth.Depth1BitPerPixel,
                    SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR24);

                return srf;
            });

        var o = mock.Object.RenderGlyphLCD(glyph, fg, bg);
        Assert.IsType<SDLSurface>(o);
    }
}
