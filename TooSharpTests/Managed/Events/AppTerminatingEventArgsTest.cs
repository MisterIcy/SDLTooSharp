using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events;

public class AppTerminatingEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppTerminating;
        ev.Common.Timestamp = 0;

        var args = new AppTerminatingEventArgs(ev);
        Assert.Equal(EventType.AppTerminating, args.Type);
        Assert.Equal((uint)0, args.Timestamp);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new AppTerminatingEventArgs(ev);
        });
    }
}
