using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Display;

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
        Assert.Equal(EventType.DisplayEvent, args.GetType());
        Assert.Equal(DisplayEventType.Disconnected, args.GetEventType());
        Assert.Equal((uint)0, args.GetTimestamp());
        Assert.Equal((uint)1, args.GetDisplayId());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
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

        Assert.Throws<ArgumentException>(() => {
            DisplayDisconnectedEventArgs args = new DisplayDisconnectedEventArgs(ev);
        });
    }
}
