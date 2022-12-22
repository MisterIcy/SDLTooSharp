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
        Assert.Equal(EventType.JoyHatMotion, args.Type);
        Assert.Equal(1, args.JoystickId);
        Assert.Equal(1, args.HatId);
        Assert.Equal(42, args.Value);
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
