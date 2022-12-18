using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Controller;

public abstract class AbstractControllerEventArgs : AbstractEventArgs
{
    protected int _which;

    protected AbstractControllerEventArgs(SDL.SDL_Event @event) : base(@event)
    {

    }

    public int GetControllerID() => _which;
}
