using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickButtonUpEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyButtonUp;
        ev.JButton.Which = 1;
        ev.JButton.Button = 1;
        ev.JButton.State = (byte)JoystickButtonState.Released;

        var args = new JoystickButtonUpEventArgs(ev);
        Assert.Equal(EventType.JoyButtonUp, args.GetType());
        Assert.Equal(1, args.GetJoystickID());
        Assert.Equal(1, args.GetButton());
        Assert.Equal(JoystickButtonState.Released, args.GetState());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickButtonUpEventArgs(ev);
        });
    }
}
