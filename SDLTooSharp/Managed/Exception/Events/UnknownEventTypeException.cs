using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Exception.Events;

[ExcludeFromCodeCoverage]
public sealed class UnknownEventTypeException : EventException
{

    public UnknownEventTypeException(SDL.SDL_Event @event) : base($"Unknown event type {@event.Type}", @event)
    {
    }
}
