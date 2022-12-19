using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Finger;

public sealed class FingerDownEventArgs : AbstractTouchFingerEventArgs
{

    public FingerDownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.FingerDown )
        {
            throw new InvalidEventTypeException(
                EventType.FingerDown,
                (EventType)@event.Type
            );
        }
    }
}
