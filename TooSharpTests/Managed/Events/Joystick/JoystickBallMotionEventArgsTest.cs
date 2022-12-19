using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickBallMotionEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyBallMotion;
        ev.JBall.Which = 1;
        ev.JBall.Ball = 1;
        ev.JBall.XRel = 42;
        ev.JBall.YRel = 21;

        var args = new JoystickBallMotionEventArgs(ev);
        Assert.Equal(EventType.JoyBallMotion, args.GetType());
        Assert.Equal(1, args.GetJoystickID());
        Assert.Equal(1, args.GetBallID());
        Assert.Equal(42, args.GetRelativeMotionX());
        Assert.Equal(21, args.GetRelativeMotionY());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickBallMotionEventArgs(ev);
        });
    }
}
