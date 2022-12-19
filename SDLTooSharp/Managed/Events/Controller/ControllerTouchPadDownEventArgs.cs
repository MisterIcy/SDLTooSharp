using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerTouchPadDownEventArgs : ControllerTouchPadEventArgs
{

    public ControllerTouchPadDownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerTouchPadDown )
        {
            throw new InvalidEventTypeException(
                EventType.ControllerTouchPadDown,
                (EventType)@event.Type
            );
        }
    }
}
