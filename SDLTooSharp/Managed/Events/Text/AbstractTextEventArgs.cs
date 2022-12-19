using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Text;

public abstract class AbstractTextEventArgs : AbstractEventArgs
{
    public string Text { get; protected set; }
    public uint WindowId { get; protected set; }

    protected AbstractTextEventArgs(SDL.SDL_Event @event) : base(@event)
    {
    }
}
