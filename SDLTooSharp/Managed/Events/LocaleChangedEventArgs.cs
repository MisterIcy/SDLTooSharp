using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public sealed class LocaleChangedEventArgs : AbstractEventArgs
{

    public LocaleChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.LocaleChanged )
        {
            throw new ArgumentException("Not a LocaleChanged event", nameof(@event));
        }
    }
}
