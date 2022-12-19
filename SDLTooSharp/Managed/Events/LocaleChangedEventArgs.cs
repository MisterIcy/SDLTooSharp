using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public sealed class LocaleChangedEventArgs : AbstractEventArgs
{

    public LocaleChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.LocaleChanged )
        {
            throw new InvalidEventTypeException(
                EventType.LocaleChanged,
                (EventType)@event.Type
            );
        }
    }
}
