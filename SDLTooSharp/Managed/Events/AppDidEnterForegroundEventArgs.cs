using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public sealed class AppDidEnterForegroundEventArgs : AbstractEventArgs
{

    public AppDidEnterForegroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppDidEnterForeground )
        {
            throw new InvalidEventTypeException(
                EventType.AppDidEnterForeground,
                (EventType)@event.Type
            );
        }
    }
}
