using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerDeviceRemappedEventArgs : ControllerDeviceEventArgs
{

    public ControllerDeviceRemappedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerDeviceRemapped )
        {
            throw new InvalidEventTypeException(
                EventType.ControllerDeviceRemapped,
                (EventType)@event.Type
            );
        }
    }
}
