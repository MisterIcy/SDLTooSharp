using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Keyboard;

public sealed class KeyUpEventArgs : AbstractKeyboardEventArgs
{

    public KeyUpEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.KeyUp )
        {
            throw new InvalidEventTypeException(
                EventType.KeyUp,
                (EventType)@event.Type
            );
        }
    }
}
