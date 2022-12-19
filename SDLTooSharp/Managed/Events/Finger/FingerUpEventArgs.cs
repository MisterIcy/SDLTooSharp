using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Finger;

public sealed class FingerUpEventArgs : AbstractTouchFingerEventArgs
{

    public FingerUpEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.FingerUp )
        {
            throw new InvalidEventTypeException(
                EventType.FingerUp,
                (EventType)@event.Type
            );
        }
    }
}
