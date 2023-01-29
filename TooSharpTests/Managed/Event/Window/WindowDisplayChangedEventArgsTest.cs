using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Window;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event.Window;

public class WindowDisplayChangedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_WINDOWEVENT;
        evt.Window.Event = (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_DISPLAY_CHANGED;
        evt.Window.Data1 = 1;
        evt.Window.Data2 = 2;
        evt.Window.WindowID = 1;

        var args = new WindowDisplayChangedEventArgs(evt);
        Assert.Equal(EventType.WindowEvent, args.EventType);
        Assert.Equal((uint)1, args.WindowId);
        Assert.Equal(1, args.Data1);
        Assert.Equal(2, args.Data2);
    }

    [Fact]
    public void FailToCreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new WindowDisplayChangedEventArgs(evt);
        });
    }

    [Fact]
    public void FailToCreateCorrectEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_WINDOWEVENT;
        evt.Display.Event = (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_NONE;

        Assert.Throws<InvalidEventIdException>(() => {
            var args = new WindowDisplayChangedEventArgs(evt);
        });
    }
}
