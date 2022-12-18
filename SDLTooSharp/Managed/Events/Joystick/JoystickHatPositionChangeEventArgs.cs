using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickHatPositionChangeEventArgs : AbstractJoysticEventArgs
{
    private byte _hatId;
    private byte _value;

    public JoystickHatPositionChangeEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyHatMotion )
        {
            throw new InvalidEventTypeException(
                "JoyHatMotion",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _which = @event.JHat.Which;
        _hatId = @event.JHat.Hat;
        _value = @event.JHat.Value;
    }

    public byte GetHatID() => _hatId;
    public byte GetValue() => _value;
}
