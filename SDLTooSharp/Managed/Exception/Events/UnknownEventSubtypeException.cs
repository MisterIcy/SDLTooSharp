using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Exception.Events;

[ExcludeFromCodeCoverage]
public sealed class UnknownEventSubtypeException : EventException
{

    public UnknownEventSubtypeException(SDL.SDL_Event @event) : base(
        $"Unknown event subtype for {@event.Type} ", @event)
    {
    }
}
