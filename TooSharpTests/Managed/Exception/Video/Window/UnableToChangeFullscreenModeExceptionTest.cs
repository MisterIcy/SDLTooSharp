using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Managed.Exception.Video.Window;
using SDLTooSharp.Managed.Video.Window;

namespace TooSharpTests.Managed.Exception.Video.Window;
[ExcludeFromCodeCoverage]
public class UnableToChangeFullscreenModeExceptionTest
{

    [Theory]
    [InlineData(WindowMode.Windowed)]
    [InlineData(WindowMode.DesktopFullscreen)]
    [InlineData(WindowMode.Fullscreen)]
    public void CreateException(WindowMode mode)
    {
        var exception = new UnableToChangeFullscreenModeException(mode);
        Assert.Equal(
            $"Unable to change the window's fullscreen mode to {mode.ToString()}",
            exception.Message);
    }
}
