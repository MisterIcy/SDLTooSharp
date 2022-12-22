using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Window;

namespace TooSharpTests.Managed.Events.Window;

public class WindowCloseEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Close;
        ev.Window.WindowID = 1;
        ev.Common.Timestamp = 0;

        WindowCloseEventArgs args = new WindowCloseEventArgs(ev);
        Assert.Equal(EventType.WindowEvent, args.Type);
        Assert.Equal(WindowEventType.Close, args.WindowEventType);
        Assert.Equal((uint)0, args.Timestamp);
        Assert.Equal((uint)1, args.WindowId);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<ArgumentException>(() => {
            WindowCloseEventArgs args = new WindowCloseEventArgs(ev);
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
            WindowCloseEventArgs args = new WindowCloseEventArgs(ev);
        });
    }
}
