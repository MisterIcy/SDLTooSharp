using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Application;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event.Application;

public class AppDidEnterForegroundEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_APP_DIDENTERFOREGROUND;

        var args = new AppDidEnterForegroundEventArgs(evt);
        Assert.Equal(EventType.AppDidEnterForeground, args.EventType);
    }

    [Fact]
    public void FailToCreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new AppDidEnterForegroundEventArgs(evt);
        });
    }
}
