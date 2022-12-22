using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events;

public class LocaleChangedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.LocaleChanged;
        ev.Quit.Timestamp = 0;

        var args = new LocaleChangedEventArgs(ev);
        Assert.Equal(EventType.LocaleChanged, args.Type);
        Assert.Equal((uint)0, args.Timestamp);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Quit.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new LocaleChangedEventArgs(ev);
        });
    }
}
