using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Display;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event.Display;

public class DisplayDisconnectedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT;
        evt.Display.Event = (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_DISCONNECTED;
        evt.Display.Data1 = 1;
        evt.Display.Display = 1;

        var args = new DisplayDisconnectedEventArgs(evt);
        Assert.Equal(EventType.DisplayEvent, args.EventType);
        Assert.Equal((uint)1, args.Display);
        Assert.Equal(1, args.Data);
    }

    [Fact]
    public void FailToCreateEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_WINDOWEVENT;
        
        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new DisplayDisconnectedEventArgs(evt);
        });
    }

    [Fact]
    public void FailToCreateCorrectEvent()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT
            
            ;
        evt.Display.Event = (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_ORIENTATION;
        
        Assert.Throws<InvalidEventIdException>(() => {
            var args = new DisplayDisconnectedEventArgs(evt);
        });
    }
}
