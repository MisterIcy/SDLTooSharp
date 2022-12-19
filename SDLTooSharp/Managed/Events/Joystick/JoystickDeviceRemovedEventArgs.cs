using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickDeviceRemovedEventArgs : JoystickDeviceEventArgs
{

    public JoystickDeviceRemovedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyDeviceRemoved )
        {
            throw new InvalidEventTypeException(
                EventType.JoyDeviceRemoved,
                (EventType)@event.Type
            );
        }
    }
}
