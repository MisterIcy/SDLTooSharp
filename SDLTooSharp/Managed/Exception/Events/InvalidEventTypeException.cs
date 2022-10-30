using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;

namespace SDLTooSharp.Managed.Exception.Events;

public sealed class InvalidEventTypeException : EventException
{

    public InvalidEventTypeException(
        EventType expected,
        EventType actual,
        SDL.SDL_Event @event
    ) : base($"Invalid event type, expected {expected} but got {actual}", @event)
    {
    }
}
