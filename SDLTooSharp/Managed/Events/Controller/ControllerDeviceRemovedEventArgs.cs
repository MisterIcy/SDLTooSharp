using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerDeviceRemovedEventArgs : ControllerDeviceEventArgs
{

    public ControllerDeviceRemovedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerDeviceRemoved )
        {
            throw new InvalidEventTypeException(
                "ControllerDeviceRemoved",
                ( (EventType)@event.Type ).ToString()
            );
        }
    }
}
