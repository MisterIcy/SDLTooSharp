using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickButtonUpEventArgs : JoystickButtonPressedEventArgs
{

    public JoystickButtonUpEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyButtonUp )
        {
            throw new InvalidEventTypeException(
                EventType.JoyButtonUp,
                (EventType)@event.Type
            );
        }
    }
}
