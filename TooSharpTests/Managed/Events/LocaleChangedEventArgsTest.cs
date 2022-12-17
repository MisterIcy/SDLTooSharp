using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;

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
        Assert.Equal(EventType.LocaleChanged, args.GetType());
        Assert.Equal((uint)0, args.GetTimestamp());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Quit.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            var args = new LocaleChangedEventArgs(ev);
        });
    }
}
