using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickButtonDownEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyButtonDown;
        ev.JButton.Which = 1;
        ev.JButton.Button = 1;
        ev.JButton.State = (byte)JoystickButtonState.Pressed;

        var args = new JoystickButtonDownEventArgs(ev);
        Assert.Equal(EventType.JoyButtonDown, args.Type);
        Assert.Equal(1, args.Which);
        Assert.Equal(1, args.Button);
        Assert.Equal(JoystickButtonState.Pressed, args.State);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickButtonDownEventArgs(ev);
        });
    }
}
