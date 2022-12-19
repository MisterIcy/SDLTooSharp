using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerTouchPadDownEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerTouchPadDown;
        ev.CTouchPad.Which = 1;
        ev.CTouchPad.Finger = 1;
        ev.CTouchPad.Touchpad = 1;
        ev.CTouchPad.X = 1.1f;
        ev.CTouchPad.Y = 2.2f;
        ev.CTouchPad.Pressure = 0.8f;

        var args = new ControllerTouchPadDownEventArgs(ev);
        Assert.Equal(EventType.ControllerTouchPadDown, args.Type);
        Assert.Equal(1, args.Which);
        Assert.Equal(1, args.TouchpadId);
        Assert.Equal(1, args.FingerId);
        Assert.Equal(1.1f, args.X);
        Assert.Equal(2.2f, args.Y);
        Assert.Equal(0.8f, args.Pressure);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerTouchPadDownEventArgs(ev);
        });
    }
}
