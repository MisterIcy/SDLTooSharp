using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Application;

public abstract class ApplicationEventArgs : CommonEventArgs
{

    protected ApplicationEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
