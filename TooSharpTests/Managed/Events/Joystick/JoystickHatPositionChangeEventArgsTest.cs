using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickHatPositionChangeEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyHatMotion;
        ev.JHat.Which = 1;
        ev.JHat.Hat = 1;
        ev.JHat.Value = 42;

        var args = new JoystickHatPositionChangeEventArgs(ev);
        Assert.Equal(EventType.JoyHatMotion, args.GetType());
        Assert.Equal(1, args.GetJoystickID());
        Assert.Equal(1, args.GetHatID());
        Assert.Equal(42, args.GetValue());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickHatPositionChangeEventArgs(ev);
        });
    }
}
