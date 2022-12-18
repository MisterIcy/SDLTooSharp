using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Window;

namespace TooSharpTests.Managed.Events.Window;

public class WindowSizeChangedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.SizeChanged;
        ev.Common.Timestamp = 0;
        ev.Window.Data1 = 10;
        ev.Window.Data2 = 20;

        WindowSizeChangedEventArgs args = new WindowSizeChangedEventArgs(ev);
        Assert.Equal(EventType.WindowEvent, args.GetType());
        Assert.Equal(WindowEventType.SizeChanged, args.GetEventType());
        Assert.Equal((uint)0, args.GetTimestamp());
        Assert.Equal(new Size(10, 20), args.GetSize());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            WindowSizeChangedEventArgs args = new WindowSizeChangedEventArgs(ev);
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
            WindowSizeChangedEventArgs args = new WindowSizeChangedEventArgs(ev);
        });
    }
}
