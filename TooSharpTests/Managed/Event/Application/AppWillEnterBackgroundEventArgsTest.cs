using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Application;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event.Application;

public class AppWillEnterBackgroundEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_APP_WILLENTERBACKGROUND;

        var args = new AppWillEnterBackgroundEventArgs(evt);
        Assert.Equal(EventType.AppWillEnterBackground, args.EventType);
    }

    [Fact]
    public void FailToCreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new AppWillEnterBackgroundEventArgs(evt);
        });
    }
}
