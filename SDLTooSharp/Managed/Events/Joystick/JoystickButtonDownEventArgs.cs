using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickButtonDownEventArgs : JoystickButtonPressedEventArgs
{

    public JoystickButtonDownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyButtonDown )
        {
            throw new InvalidEventTypeException(
                EventType.JoyButtonDown,
                (EventType)@event.Type
            );
        }
    }
}
