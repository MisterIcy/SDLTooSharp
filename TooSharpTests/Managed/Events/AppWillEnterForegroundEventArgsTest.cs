using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;

namespace TooSharpTests.Managed.Events;

public class AppWillEnterForegroundEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppWillEnterForeground;
        ev.Common.Timestamp = 0;

        var args = new AppWillEnterForegroundEventArgs(ev);
        Assert.Equal(EventType.AppWillEnterForeground, args.Type);
        Assert.Equal((uint)0, args.Timestamp);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            var args = new AppWillEnterForegroundEventArgs(ev);
        });
    }
}
