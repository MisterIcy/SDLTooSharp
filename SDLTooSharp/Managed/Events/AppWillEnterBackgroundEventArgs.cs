using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public sealed class AppWillEnterBackgroundEventArgs : AbstractEventArgs
{

    public AppWillEnterBackgroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppWillEnterBackground )
        {
            throw new InvalidEventTypeException(
                EventType.AppWillEnterBackground,
                (EventType)@event.Type
            );
        }
    }
}
