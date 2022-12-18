using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Keyboard;

namespace SDLTooSharp.Managed.Events.Joystick;

public abstract class JoystickButtonPressedEventArgs : AbstractJoysticEventArgs
{

    private byte _button;
    private JoystickButtonState _state;
    protected JoystickButtonPressedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        _button = @event.JButton.Button;
        _state = (JoystickButtonState)@event.JButton.State;
        _which = @event.JButton.Which;
    }

    public byte GetButton() => _button;
    public JoystickButtonState GetState() => _state;
}
