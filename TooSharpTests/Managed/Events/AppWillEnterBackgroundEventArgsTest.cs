using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;

namespace TooSharpTests.Managed.Events;

public class AppWillEnterBackgroundEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppWillEnterBackground;
        ev.Common.Timestamp = 0;

        var args = new AppWillEnterBackgroundEventArgs(ev);
        Assert.Equal(EventType.AppWillEnterBackground, args.GetType());
        Assert.Equal((uint)0, args.GetTimestamp());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            var args = new AppWillEnterBackgroundEventArgs(ev);
        });
    }
}
