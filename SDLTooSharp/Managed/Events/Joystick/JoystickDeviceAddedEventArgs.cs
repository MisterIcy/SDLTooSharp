using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickDeviceAddedEventArgs : JoystickDeviceEventArgs
{

    public JoystickDeviceAddedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyDeviceAdded )
        {
            throw new InvalidEventTypeException(
                EventType.JoyDeviceAdded,
                (EventType)@event.Type
            );
        }
    }
}
