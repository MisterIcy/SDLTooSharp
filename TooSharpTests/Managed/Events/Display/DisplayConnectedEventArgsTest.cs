using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Display;

public class DisplayConnectedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = (byte)DisplayEventType.Connected;
        ev.Common.Timestamp = 0;
        ev.Display.Display = 1;

        DisplayConnectedEventArgs args = new DisplayConnectedEventArgs(ev);
        Assert.Equal(EventType.DisplayEvent, args.Type);
        Assert.Equal(DisplayEventType.Connected, args.DisplayEventType);
        Assert.Equal((uint)0, args.Timestamp);
        Assert.Equal(1, args.Data);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            DisplayConnectedEventArgs args = new DisplayConnectedEventArgs(ev);
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
            DisplayConnectedEventArgs args = new DisplayConnectedEventArgs(ev);
        });
    }
}
