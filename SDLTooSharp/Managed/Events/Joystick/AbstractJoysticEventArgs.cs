using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Joystick;

public abstract class AbstractJoysticEventArgs : AbstractEventArgs
{
    protected int _which;

    protected AbstractJoysticEventArgs(SDL.SDL_Event @event) : base(@event)
    {

    }

    public virtual int GetJoystickID() => _which;
}
