using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Controller;

public abstract class AbstractControllerEventArgs : AbstractEventArgs
{
    /// <summary>
    /// The Id of the Controller
    /// </summary>
    public int ControllerId
    {
        get;
        protected set;
    }

    protected AbstractControllerEventArgs(SDL.SDL_Event @event) : base(@event)
    {

    }
}
