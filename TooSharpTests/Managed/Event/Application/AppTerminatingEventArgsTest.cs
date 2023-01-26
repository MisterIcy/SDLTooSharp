using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Application;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event.Application;

public class AppTerminatingEventArgsTest
{
    [Fact]
    public void CreateAppTerminatingEventArgs()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_APP_TERMINATING;

        var args = new AppTerminatingEventArgs(evt);
        Assert.Equal(EventType.AppTerminating, args.EventType);
    }

    [Fact]
    public void CreateAppTerminatingEventArgsFailure()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new AppTerminatingEventArgs(evt);
        });
    }
}
