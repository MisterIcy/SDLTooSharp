using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;

public class LocaleChangedEventArgs : ApplicationEventArgs
{

    public LocaleChangedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.LocaleChanged )
        {
            throw new InvalidEventTypeException(
                EventType.LocaleChanged,
                EventType,
                ev
            );
        }
    }
}
