using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Display;

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
        Assert.Equal(EventType.DisplayEvent, args.GetType());
        Assert.Equal(DisplayEventType.OrientationChanged, args.GetEventType());
        Assert.Equal((uint)0, args.GetTimestamp());
        Assert.Equal((uint)1, args.GetDisplayId());
        Assert.Equal(DisplayOrientation.Portrait, args.GetDisplayOrientation());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
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

        Assert.Throws<ArgumentException>(() => {
            DisplayOrientationChangedEventArgs args = new DisplayOrientationChangedEventArgs(ev);
        });
    }
}
