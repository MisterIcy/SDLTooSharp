using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerDeviceAddedEventArgs : ControllerDeviceEventArgs
{

    public ControllerDeviceAddedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerDeviceAdded )
        {
            throw new InvalidEventTypeException(
                EventType.ControllerDeviceAdded,
                (EventType)@event.Type
            );
        }
    }
}
