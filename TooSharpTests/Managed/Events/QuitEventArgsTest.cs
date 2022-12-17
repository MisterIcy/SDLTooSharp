using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;

namespace TooSharpTests.Managed.Events;

public class QuitEventArgsTest
{
    [Fact]
    public void CreateQuitEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;
        ev.Quit.Timestamp = 0;

        var args = new QuitEventArgs(ev);
        Assert.Equal(EventType.Quit, args.GetType());
        Assert.Equal((uint)0, args.GetTimestamp());
    }

    [Fact]
    public void CreateInvalidQuitEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Quit.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            var args = new QuitEventArgs(ev);
        });
    }
}
