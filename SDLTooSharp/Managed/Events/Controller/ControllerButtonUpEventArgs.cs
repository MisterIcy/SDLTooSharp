using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerButtonUpEventArgs : ControllerButtonPressedEventArgs
{

    public ControllerButtonUpEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerButtonUp )
        {
            throw new InvalidEventTypeException(
                "ControllerButtonUp",
                ( (EventType)@event.Type ).ToString()
            );
        }
    }
}
