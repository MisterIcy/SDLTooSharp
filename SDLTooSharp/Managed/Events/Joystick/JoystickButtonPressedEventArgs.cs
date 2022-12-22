using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Keyboard;

namespace SDLTooSharp.Managed.Events.Joystick;

public abstract class JoystickButtonPressedEventArgs : AbstractJoysticEventArgs
{

    public byte Button { get; }
    public JoystickButtonState State { get; }
    protected JoystickButtonPressedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        Button = @event.JButton.Button;
        State = (JoystickButtonState)@event.JButton.State;
        JoystickId = @event.JButton.Which;
    }
}
