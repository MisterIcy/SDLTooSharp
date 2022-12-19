using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickAxisMotionEventArgs : AbstractJoysticEventArgs
{

    public byte AxisID { get; }
    public short Value { get; }
    public JoystickAxisMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyAxisMotion )
        {
            throw new InvalidEventTypeException(
                EventType.JoyAxisMotion,
                (EventType)@event.Type
            );
        }

        AxisID = @event.JAxis.Axis;
        Value = @event.JAxis.Value;
        Which = @event.JAxis.Which;
    }
}
