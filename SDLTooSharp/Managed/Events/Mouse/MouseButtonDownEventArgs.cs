using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public sealed class MouseButtonDownEventArgs : AbstractMouseButtonEventArgs
{

    public MouseButtonDownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.MouseButtonDown )
        {
            throw new InvalidEventTypeException(
                EventType.MouseButtonDown,
                (EventType)@event.Type
            );
        }
    }
}
