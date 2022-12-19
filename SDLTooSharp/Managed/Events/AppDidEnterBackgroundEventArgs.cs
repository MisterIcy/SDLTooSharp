using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public sealed class AppDidEnterBackgroundEventArgs : AbstractEventArgs
{

    public AppDidEnterBackgroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppDidEnterBackground )
        {
            throw new InvalidEventTypeException(
                EventType.AppDidEnterBackground,
                (EventType)@event.Type
            );
        }
    }
}
