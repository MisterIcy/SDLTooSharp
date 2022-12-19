using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Display;

public class DisplayDisconnectedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = (byte)DisplayEventType.Disconnected;
        ev.Common.Timestamp = 0;
        ev.Display.Display = 1;

        DisplayDisconnectedEventArgs args = new DisplayDisconnectedEventArgs(ev);
        Assert.Equal(EventType.DisplayEvent, args.Type);
        Assert.Equal(DisplayEventType.Disconnected, args.DisplayEventType);
        Assert.Equal((uint)0, args.Timestamp);
        Assert.Equal((uint)1, args.DisplayId);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            DisplayDisconnectedEventArgs args = new DisplayDisconnectedEventArgs(ev);
        });
    }

    [Fact]
    public void CreateInvalidDisplayEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = 0;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidDisplaySubtypeEventException>(() => {
            DisplayDisconnectedEventArgs args = new DisplayDisconnectedEventArgs(ev);
        });
    }
}
