using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Mouse;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Mouse;

public class MouseButtonUpEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.MouseButtonUp;
        ev.Button.WindowID = 1;
        ev.Button.Which = 1;
        ev.Button.Clicks = 1;
        ev.Button.Button = 1;
        ev.Button.State = 0b00000001;
        ev.Button.X = 10;
        ev.Button.Y = 10;

        var args = new MouseButtonUpEventArgs(ev);
        Assert.Equal(EventType.MouseButtonUp, args.Type);
        Assert.Equal((uint)1, args.WindowId);
        Assert.Equal((uint)1, args.Which);
        Assert.Equal(new MouseState(0b00000001), args.MouseState);
        Assert.Equal(1, args.Clicks);
        Assert.Equal(MouseButton.Left, args.Button);
        Assert.Equal(10, args.X);
        Assert.Equal(10, args.Y);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.MouseButtonDown;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new MouseButtonUpEventArgs(ev);
        });
    }

    [Fact]
    public void CreateInvalidNonMouseEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new MouseButtonUpEventArgs(ev);
        });
    }
}
