using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;

namespace TooSharpTests.Managed.Events;

public class AppDidEnterBackgroundEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppDidEnterBackground;
        ev.Quit.Timestamp = 0;

        var args = new AppDidEnterBackgroundEventArgs(ev);
        Assert.Equal(EventType.AppDidEnterBackground, args.GetType());
        Assert.Equal((uint)0, args.GetTimestamp());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Quit.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            var args = new AppDidEnterBackgroundEventArgs(ev);
        });
    }
}
