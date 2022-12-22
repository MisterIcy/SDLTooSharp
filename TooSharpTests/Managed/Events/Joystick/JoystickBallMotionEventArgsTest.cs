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
        Assert.Equal(EventType.JoyBallMotion, args.Type);
        Assert.Equal(1, args.Which);
        Assert.Equal(1, args.BallId);
        Assert.Equal(42, args.RelativeX);
        Assert.Equal(21, args.RelativeY);
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
