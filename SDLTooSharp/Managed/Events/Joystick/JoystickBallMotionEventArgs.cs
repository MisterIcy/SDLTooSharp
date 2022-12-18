using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickBallMotionEventArgs : AbstractJoysticEventArgs
{

    private byte _ballId;
    private short _xRel;
    private short _yRel;
    public JoystickBallMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyBallMotion )
        {
            throw new InvalidEventTypeException(
                "JoyBallMotion",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _ballId = @event.JBall.Ball;
        _xRel = @event.JBall.XRel;
        _yRel = @event.JBall.YRel;
        _which = @event.JBall.Which;
    }

    public byte GetBallID() => _ballId;
    public short GetRelativeMotionX() => _xRel;
    public short GetRelativeMotionY() => _yRel;
}
