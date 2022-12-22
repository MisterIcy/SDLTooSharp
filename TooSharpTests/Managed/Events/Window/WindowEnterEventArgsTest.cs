using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Window;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Window;

public class WindowEnterEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Enter;
        ev.Common.Timestamp = 0;

        WindowEnterEventArgs args = new WindowEnterEventArgs(ev);
        Assert.Equal(EventType.WindowEvent, args.Type);
        Assert.Equal(WindowEventType.Enter, args.WindowEventType);
        Assert.Equal((uint)0, args.Timestamp);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            WindowEnterEventArgs args = new WindowEnterEventArgs(ev);
        });
    }

    [Fact]
    public void CreateInvalidWindowEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = 0;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidWindowSubtypeEventException>(() => {
            WindowEnterEventArgs args = new WindowEnterEventArgs(ev);
        });
    }
}
