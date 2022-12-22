using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickDeviceRemovedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyDeviceRemoved;
        ev.JDevice.Which = 1;

        var args = new JoystickDeviceRemovedEventArgs(ev);
        Assert.Equal(EventType.JoyDeviceRemoved, args.Type);
        Assert.Equal(1, args.Which);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickDeviceRemovedEventArgs(ev);
        });
    }
}
