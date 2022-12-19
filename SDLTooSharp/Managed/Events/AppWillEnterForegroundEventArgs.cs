using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public class AppWillEnterForegroundEventArgs : AbstractEventArgs
{

    public AppWillEnterForegroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppWillEnterForeground )
        {
            throw new InvalidEventTypeException(
                EventType.AppWillEnterForeground,
                (EventType)@event.Type
            );
        }
    }
}
