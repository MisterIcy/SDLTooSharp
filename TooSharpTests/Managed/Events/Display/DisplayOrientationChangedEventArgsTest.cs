using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Display;

public class DisplayOrientationChangedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = (byte)DisplayEventType.OrientationChanged;
        ev.Common.Timestamp = 0;
        ev.Display.Display = 1;
        ev.Display.Data1 = (int)DisplayOrientation.Portrait;

        DisplayOrientationChangedEventArgs args = new DisplayOrientationChangedEventArgs(ev);
        Assert.Equal(EventType.DisplayEvent, args.Type);
        Assert.Equal(DisplayEventType.OrientationChanged, args.DisplayEventType);
        Assert.Equal((uint)0, args.Timestamp);
        Assert.Equal((uint)1, args.DisplayId);
        Assert.Equal(DisplayOrientation.Portrait, args.DisplayOrientation);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            DisplayOrientationChangedEventArgs args = new DisplayOrientationChangedEventArgs(ev);
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
            DisplayOrientationChangedEventArgs args = new DisplayOrientationChangedEventArgs(ev);
        });
    }
}
