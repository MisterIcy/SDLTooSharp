using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Keyboard;

public sealed class KeyDownEventArgs : AbstractKeyboardEventArgs
{

    public KeyDownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.KeyDown )
        {
            throw new InvalidEventTypeException(
                "KeyDown",
                ( (EventType)@event.Type ).ToString()
            );
        }
    }
}
