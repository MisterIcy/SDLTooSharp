using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Controller;

public abstract class ControllerDeviceEventArgs : AbstractControllerEventArgs
{

    protected ControllerDeviceEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        ControllerId = @event.CDevice.Which;
    }
}
