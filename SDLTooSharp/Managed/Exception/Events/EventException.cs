using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Exception.Events;

public abstract class EventException : SDLException
{
    public SDL.SDL_Event Event { get; }

    protected EventException(string message, SDL.SDL_Event @event) : base(message)
    {
        Event = @event;
    }
}
