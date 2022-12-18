using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickAxisMotionEventArgs : AbstractJoysticEventArgs
{

    private byte _axisID;
    private short _value;
    public JoystickAxisMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyAxisMotion )
        {
            throw new InvalidEventTypeException(
                "JoyAxisMotion",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _axisID = @event.JAxis.Axis;
        _value = @event.JAxis.Value;
        _which = @event.JAxis.Which;
    }

    public byte GetAxisID() => _axisID;
    public short GetValue() => _value;
}
