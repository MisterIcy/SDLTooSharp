using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Joystick;

namespace SDLTooSharp.Managed.Events.Controller;

public abstract class ControllerButtonPressedEventArgs : AbstractControllerEventArgs
{
    private readonly ControllerButton _button;
    private readonly ControllerButtonState _state;

    protected ControllerButtonPressedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        _which = @event.CButton.Which;
        _button = (ControllerButton)@event.CButton.Button;
        _state = (ControllerButtonState)@event.CButton.State;
    }

    public ControllerButton GetButton() => _button;
    public ControllerButtonState GetState() => _state;
}
