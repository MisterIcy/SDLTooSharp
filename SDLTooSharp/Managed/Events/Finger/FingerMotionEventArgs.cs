using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Finger;

public sealed class FingerMotionEventArgs : AbstractTouchFingerEventArgs
{

    public FingerMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.FingerMotion )
        {
            throw new InvalidEventTypeException(
                EventType.FingerMotion,
                (EventType)@event.Type
            );
        }
    }
}
