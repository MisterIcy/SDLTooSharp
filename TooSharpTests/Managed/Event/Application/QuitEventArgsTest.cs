using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Application;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event.Application;

public class QuitEventArgsTest
{
    [Fact]
    public void CreateQuitEventArgs()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_QUIT;
        evt.Quit.Timestamp = 1;

        var args = new QuitEventArgs(evt);
        Assert.Equal(EventType.Quit, args.EventType);
    }

    [Fact]
    public void CreateQuitEventArgsFailure()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT;
        evt.Quit.Timestamp = 1;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new QuitEventArgs(evt);
        });
    }
}
