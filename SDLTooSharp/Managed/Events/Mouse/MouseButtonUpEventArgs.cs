using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public sealed class MouseButtonUpEventArgs : AbstractMouseButtonEventArgs
{

    public MouseButtonUpEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.MouseButtonUp )
        {
            throw new InvalidEventTypeException(
                EventType.MouseButtonUp,
                (EventType)@event.Type
            );
        }
    }
}
