using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events;

public class AppDidEnterForegroundEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppDidEnterForeground;
        ev.Common.Timestamp = 0;

        var args = new AppDidEnterForegroundEventArgs(ev);
        Assert.Equal(EventType.AppDidEnterForeground, args.Type);
        Assert.Equal((uint)0, args.Timestamp);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new AppDidEnterForegroundEventArgs(ev);
        });
    }
}
