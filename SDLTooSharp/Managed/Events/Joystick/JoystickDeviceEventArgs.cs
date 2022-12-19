using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Joystick;

public abstract class JoystickDeviceEventArgs : AbstractJoysticEventArgs
{

    protected JoystickDeviceEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        Which = @event.JDevice.Which;
    }
}
