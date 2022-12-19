using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Joystick;

public abstract class AbstractJoysticEventArgs : AbstractEventArgs
{
    public int Which { get; protected set; }

    protected AbstractJoysticEventArgs(SDL.SDL_Event @event) : base(@event)
    {

    }
}
