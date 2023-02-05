using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Video.Window;

namespace TooSharpTests.Managed.Video.Window;

public class SDLWindowTest
{
    [Fact]
    public void CreateSDLWindow()
    {
        int result = SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
        Assert.Equal(0, result);
        var window = new SDLWindow("Test", new Point2(0, 0), new Size(100, 100));

        Assert.IsType<SDLWindow>(window);
        Assert.Equal(new Point2(0, 0), window.Position);
        Assert.Equal(new Size(100, 100), window.Size);
        window.Dispose();
        Assert.Equal(IntPtr.Zero, window.WindowPtr);
        SDL.SDL_Quit();
    }
}
