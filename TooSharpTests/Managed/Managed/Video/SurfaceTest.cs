using System.Diagnostics.CodeAnalysis;
using Moq;
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
}
