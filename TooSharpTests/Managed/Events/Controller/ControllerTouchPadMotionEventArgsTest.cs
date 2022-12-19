using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerTouchPadMotionEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerTouchPadMotion;
        ev.CTouchPad.Which = 1;
        ev.CTouchPad.Finger = 1;
        ev.CTouchPad.Touchpad = 1;
        ev.CTouchPad.X = 1.1f;
        ev.CTouchPad.Y = 2.2f;
        ev.CTouchPad.Pressure = 0.8f;

        var args = new ControllerTouchPadMotionEventArgs(ev);
        Assert.Equal(EventType.ControllerTouchPadMotion, args.GetType());
        Assert.Equal(1, args.GetControllerID());
        Assert.Equal(1, args.GetTouchPadID());
        Assert.Equal(1, args.GetFingerId());
        Assert.Equal(1.1f, args.GetX());
        Assert.Equal(2.2f, args.GetY());
        Assert.Equal(0.8f, args.GetPressure());
        Assert.Equal(new Point2F(1.1f, 2.2f), args.GetPoint());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerTouchPadMotionEventArgs(ev);
        });
    }
}
