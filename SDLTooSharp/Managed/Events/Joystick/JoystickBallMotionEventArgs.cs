using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickBallMotionEventArgs : AbstractJoysticEventArgs
{

    public byte BallId { get; }
    public short RelativeX { get; }
    public short RelativeY { get; }
    public JoystickBallMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyBallMotion )
        {
            throw new InvalidEventTypeException(
                EventType.JoyBallMotion,
                (EventType)@event.Type
            );
        }

        BallId = @event.JBall.Ball;
        RelativeX = @event.JBall.XRel;
        RelativeY = @event.JBall.YRel;
        Which = @event.JBall.Which;
    }
}
