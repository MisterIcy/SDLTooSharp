using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Text;

public abstract class AbstractTextEventArgs : AbstractEventArgs
{
    protected string _text;
    protected uint _windowId;

    protected AbstractTextEventArgs(SDL.SDL_Event @event) : base(@event)
    {
    }

    public virtual string GetText() => _text;
    public virtual uint GetWindowID() => _windowId;
}
