using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Window;

namespace TooSharpTests.Managed.Events.Window;

public class WindowMovedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Moved;
        ev.Common.Timestamp = 0;
        ev.Window.Data1 = 10;
        ev.Window.Data2 = 20;

        WindowMovedEventArgs args = new WindowMovedEventArgs(ev);
        Assert.Equal(EventType.WindowEvent, args.GetType());
        Assert.Equal(WindowEventType.Moved, args.GetEventType());
        Assert.Equal((uint)0, args.GetTimestamp());
        Assert.Equal(new Point2(10, 20), args.GetPosition());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            WindowMovedEventArgs args = new WindowMovedEventArgs(ev);
        });
    }

    [Fact]
    public void CreateInvalidDisplayEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = 0;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            WindowMovedEventArgs args = new WindowMovedEventArgs(ev);
        });
    }
}
