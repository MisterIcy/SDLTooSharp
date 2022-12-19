using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickHatPositionChangeEventArgs : AbstractJoysticEventArgs
{
    public byte HatId { get; }
    public byte Value { get; }

    public JoystickHatPositionChangeEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyHatMotion )
        {
            throw new InvalidEventTypeException(
                EventType.JoyHatMotion,
                (EventType)@event.Type
            );
        }

        Which = @event.JHat.Which;
        HatId = @event.JHat.Hat;
        Value = @event.JHat.Value;
    }
}
