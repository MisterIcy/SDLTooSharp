using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerTouchPadMotionEventArgs : ControllerTouchPadEventArgs
{

    public ControllerTouchPadMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerTouchPadMotion )
        {
            throw new InvalidEventTypeException(
                "ControllerTouchPadMotion",
                ( (EventType)@event.Type ).ToString()
            );
        }
    }
}
