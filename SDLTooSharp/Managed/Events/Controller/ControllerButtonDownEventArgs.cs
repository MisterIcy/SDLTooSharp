using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerButtonDownEventArgs : ControllerButtonPressedEventArgs
{

    public ControllerButtonDownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerButtonDown )
        {
            throw new InvalidEventTypeException(
                EventType.ControllerButtonDown,
                (EventType)@event.Type
            );
        }
    }
}
