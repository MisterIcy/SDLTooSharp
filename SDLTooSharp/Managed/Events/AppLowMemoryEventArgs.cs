using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public sealed class AppLowMemoryEventArgs : AbstractEventArgs
{

    public AppLowMemoryEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppLowMemory )
        {
            throw new InvalidEventTypeException(
                EventType.AppLowMemory,
                (EventType)@event.Type
                );
        }
    }
}
