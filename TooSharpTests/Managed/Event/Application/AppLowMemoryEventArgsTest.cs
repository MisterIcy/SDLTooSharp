using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Application;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event.Application;

public class AppLowMemoryEventArgsTest
{
    [Fact]
    public void CreateAppLowMemoryEventArgs()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_APP_LOWMEMORY;

        var args = new AppLowMemoryEventArgs(evt);
        Assert.Equal(EventType.AppLowMemory, args.EventType);
    }

    [Fact]
    public void CreateAppTerminatingEventArgsFailure()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new AppLowMemoryEventArgs(evt);
        });
    }
}
