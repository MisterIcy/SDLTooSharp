using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Window;

namespace TooSharpTests.Managed.Events.Window;

public class WindowMinimizedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Minimized;
        ev.Common.Timestamp = 0;

        WindowMinimizedEventArgs args = new WindowMinimizedEventArgs(ev);
        Assert.Equal(EventType.WindowEvent, args.GetType());
        Assert.Equal(WindowEventType.Minimized, args.GetEventType());
        Assert.Equal((uint)0, args.GetTimestamp());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            WindowMinimizedEventArgs args = new WindowMinimizedEventArgs(ev);
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
            WindowMinimizedEventArgs args = new WindowMinimizedEventArgs(ev);
        });
    }
}
