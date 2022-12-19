using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerTouchPadUpEventArgs : ControllerTouchPadEventArgs
{

    public ControllerTouchPadUpEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerTouchPadUp )
        {
            throw new InvalidEventTypeException(
                EventType.ControllerTouchPadUp,
                (EventType)@event.Type
            );
        }
    }
}
