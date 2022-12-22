using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Joystick;

namespace SDLTooSharp.Managed.Events.Controller;

public abstract class ControllerButtonPressedEventArgs : AbstractControllerEventArgs
{
    public ControllerButton Button { get; }
    public ControllerButtonState State { get; }

    protected ControllerButtonPressedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        ControllerId = @event.CButton.Which;
        Button = (ControllerButton)@event.CButton.Button;
        State = (ControllerButtonState)@event.CButton.State;
    }
}
