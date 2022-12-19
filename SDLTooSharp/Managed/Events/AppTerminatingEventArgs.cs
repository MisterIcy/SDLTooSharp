using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public sealed class AppTerminatingEventArgs : AbstractEventArgs
{

    public AppTerminatingEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppTerminating )
        {
            throw new InvalidEventTypeException(
                EventType.AppTerminating,
                (EventType)@event.Type
                );
        }
    }
}
