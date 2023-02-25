using System.Diagnostics.CodeAnalysis;
using Moq;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Surface;
using SDLTooSharp.Managed.Video.Surface;

namespace TooSharpTests.Managed.Managed.Video;

[ExcludeFromCodeCoverage]
public class SurfaceTest
{
    [Fact]
    public void TestGetDimensions()
    {
        var dimensions = new Size(100, 100);
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.Dimensions)
            .Returns(dimensions);

        Assert.Equal(dimensions, surfaceMock.Object.Dimensions);
    }

    [Fact]
    public void TestGetPitch()
    {
        int pitch = 100;
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.Pitch)
            .Returns(pitch);

        Assert.Equal(pitch, surfaceMock.Object.Pitch);
    }

    [Fact]
    public void TestGetPixelPointer()
    {
        IntPtr pixelPtr = IntPtr.Zero;
        var surfaceMock = new Mock<ISurface>();

        surfaceMock.SetupGet(x => x.Pixels)
            .Returns(pixelPtr);

        Assert.Equal(pixelPtr, surfaceMock.Object.Pixels);
    }

    [Fact]
    public void TestIsLocked()
    {
        var surfaceMock = new Mock<ISurface>();

        surfaceMock.Setup(x => x.Lock());
        surfaceMock.SetupGet(x => x.IsLocked)
            .Returns(true);

        surfaceMock.Object.Lock();
        Assert.True(surfaceMock.Object.IsLocked);
    }

    [Fact]
    public void TestUnlock()
    {
        var surfaceMock = new Mock<ISurface>();

        surfaceMock.Setup(x => x.Unlock());
        surfaceMock.SetupGet(x => x.IsLocked)
            .Returns(false);

        surfaceMock.Object.Unlock();
        Assert.False(surfaceMock.Object.IsLocked);
    }

    [Fact]
    public void TestUnableToLock()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.Setup(x => x.Lock())
            .Throws<UnableToLockSurfaceException>();

        Assert.Throws<UnableToLockSurfaceException>(() => surfaceMock.Object.Lock());
    }

    [Fact]
    public void TestHasColorKey()
    {
        Color key = new Color(255, 0, 255);
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.ColorKey)
            .Returns(key);

        Assert.Equal(key, surfaceMock.Object.ColorKey);
    }

    [Fact]
    public void TestDoesNotHaveColorKey()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.ColorKey)
            .Returns(() => null);

        Assert.Null(surfaceMock.Object.ColorKey);
    }

    [Fact]
    public void TestCannotRetrieveColorKey()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.ColorKey)
            .Throws<UnableToGetSurfaceColorKeyException>();

        Assert.Throws<UnableToGetSurfaceColorKeyException>(
            () => {
                Color? objectColorKey = surfaceMock.Object.ColorKey;
            });
    }

    [Fact]
    public void TestSetColorKey()
    {
        Color key = new Color(0, 0, 0);
        Color expected = new Color(255, 0, 255);
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.ColorKey = expected).Callback<Color>(v => key = v);

        surfaceMock.Object.ColorKey = expected;
        Assert.Equal(expected, key);
    }

    [Fact]
    public void TestUnsetColorKey()
    {
        Color key = new Color(255, 0, 255);
        Color? expected = new Color(255, 0, 255);
        var surfaceMock = new Mock<ISurface>();
        surfaceMock
            .SetupSet(x => x.ColorKey = null)
            .Callback<Color?>(v => expected = v);

        surfaceMock.Object.ColorKey = null;
        Assert.Null(expected);
    }

    [Fact]
    public void TestCannotSetColorKey()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.ColorKey = null)
            .Throws<UnableToSetSurfaceColorKeyException>();

        Assert.Throws<UnableToSetSurfaceColorKeyException>(
            () => { surfaceMock.Object.ColorKey = null; });
    }

    [Fact]
    public void GetColorMod()
    {
        var mod = new Color(255, 255, 255);
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.ColorMod)
            .Returns(mod);

        Assert.Equal(mod, surfaceMock.Object.ColorMod);
    }

    [Fact]
    public void UnableToGetColorMod()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.ColorMod)
            .Throws<UnableToGetSurfaceColorModException>();

        Assert.Throws<UnableToGetSurfaceColorModException>(() => {
            var color = surfaceMock.Object.ColorMod;
        });
    }

    [Fact]
    public void SetColorMod()
    {
        var mod = new Color(0, 222, 255);
        var expected = new Color(0, 0, 0);

        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.ColorMod = mod)
            .Callback<Color>(v => expected = v);

        surfaceMock.Object.ColorMod = mod;
        Assert.Equal(expected, mod);
    }

    [Fact]
    public void ResetColorMod()
    {
        var mod = new Color(255, 255, 255);

        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.ColorMod = It.IsAny<Color?>());
        surfaceMock.SetupGet(x => x.ColorMod)
            .Returns(mod);

        surfaceMock.Object.ColorMod = null;
        Assert.Equal(mod, surfaceMock.Object.ColorMod);
    }

    [Fact]
    public void UnableToSetColorMod()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.ColorMod = It.IsAny<Color?>())
            .Throws<UnableToSetSurfaceColorModException>();

        Assert.Throws<UnableToSetSurfaceColorModException>(
            () => surfaceMock.Object.ColorMod = null);
    }

    [Fact]
    public void GetAlphaMod()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.AlphaMod)
            .Returns(192);

        Assert.Equal(192, surfaceMock.Object.AlphaMod);
    }

    [Fact]
    public void UnableToGetAlphaMod()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.AlphaMod)
            .Throws<UnableToGetSurfaceAlphaModException>();

        Assert.Throws<UnableToGetSurfaceAlphaModException>(
            () => {
                byte mod = surfaceMock.Object.AlphaMod;
            });
    }

    [Fact]
    public void SetAlphaMod()
    {
        byte expected = 0;
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.AlphaMod = It.IsAny<byte>())
            .Callback<byte>(x => expected = x);

        surfaceMock.Object.AlphaMod = 192;
        Assert.Equal(192, expected);
    }

    [Fact]
    public void UnableToSetAlphaMod()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.AlphaMod = It.IsAny<byte>())
            .Throws<UnableToSetSurfaceAlphaModException>();

        Assert.Throws<UnableToSetSurfaceAlphaModException>(
            () => surfaceMock.Object.AlphaMod = 192);
    }

    [Fact]
    public void GetBlendMode()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.BlendMode)
            .Returns(SDL.SDL_BlendMode.SDL_BLENDMODE_ADD);

        Assert.Equal(SDL.SDL_BlendMode.SDL_BLENDMODE_ADD, surfaceMock.Object.BlendMode);
    }

    [Fact]
    public void UnableToGetBlendMode()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.BlendMode)
            .Throws<UnableToGetSurfaceBlendModeException>();

        Assert.Throws<UnableToGetSurfaceBlendModeException>(
            () => {
                var mode = surfaceMock.Object.BlendMode;
            });
    }

    [Fact]
    public void SetBlendMode()
    {
        var mode = SDL.SDL_BlendMode.SDL_BLENDMODE_NONE;
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.BlendMode = It.IsAny<SDL.SDL_BlendMode>())
            .Callback<SDL.SDL_BlendMode>(v => mode = v);

        surfaceMock.Object.BlendMode = SDL.SDL_BlendMode.SDL_BLENDMODE_MOD;
        Assert.Equal(SDL.SDL_BlendMode.SDL_BLENDMODE_MOD, mode);
    }

    [Fact]
    public void UnableToSetBlendMode()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.BlendMode = It.IsAny<SDL.SDL_BlendMode>())
            .Throws<UnableToSetSurfaceBlendModeException>();

        Assert.Throws<UnableToSetSurfaceBlendModeException>(
            () => surfaceMock.Object.BlendMode = SDL.SDL_BlendMode.SDL_BLENDMODE_ADD);
    }


    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void GetRle(bool rle)
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupGet(x => x.RLE)
            .Returns(rle);

        Assert.Equal(rle, surfaceMock.Object.RLE);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void SetRle(bool rle)
    {
        bool? expected = null;
        var surfaceMock = new Mock<ISurface>();

        surfaceMock.SetupSet(x => x.RLE = It.IsAny<bool>())
            .Callback<bool>(v => expected = v);

        surfaceMock.Object.RLE = rle;
        Assert.Equal(expected, rle);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void UnableToSetRle(bool rle)
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.SetupSet(x => x.RLE = It.IsAny<bool>())
            .Throws(() => new UnableToSetRLEException(rle));

        Assert.Throws<UnableToSetRLEException>(() => surfaceMock.Object.RLE = rle);
    }

    [Fact]
    public void DuplicateSurface()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.Setup(x => x.Duplicate())
            .Returns(() => {
                var srf = new SDLSurface(
                    new Size(1, 2),
                    SurfaceDepth.Depth1BitPerPixel,
                    SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR24);

                return srf;
            });

        var surface = surfaceMock.Object.Duplicate();
        Assert.IsType<SDLSurface>(surface);
    }

    [Fact]
    public void UnableToDuplicate()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.Setup(x => x.Duplicate())
            .Throws<UnableToDuplicateSurfaceException>();

        Assert.Throws<UnableToDuplicateSurfaceException>(() => {
            var surface = surfaceMock.Object.Duplicate();
        });
    }

    [Fact]
    public void ConvertSurface()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.Setup(x => x.Convert(1234))
            .Returns(() => {
                var srf = new SDLSurface(
                    new Size(1, 2),
                    SurfaceDepth.Depth1BitPerPixel,
                    SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR24);

                return srf;
            });

        var surface = surfaceMock.Object.Convert(1234);
        Assert.IsType<SDLSurface>(surface);
    }

    [Fact]
    public void UnableToConvertSurface()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.Setup(x => x.Convert(1234))
            .Throws<UnableToConvertSurfaceException>();

        Assert.Throws<UnableToConvertSurfaceException>(() => {
            var surface = surfaceMock.Object.Convert(1234);
        });
    }
}
