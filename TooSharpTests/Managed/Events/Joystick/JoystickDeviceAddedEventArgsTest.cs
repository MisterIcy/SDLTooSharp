using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickDeviceAddedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyDeviceAdded;
        ev.JDevice.Which = 1;

        var args = new JoystickDeviceAddedEventArgs(ev);
        Assert.Equal(EventType.JoyDeviceAdded, args.Type);
        Assert.Equal(1, args.Which);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickDeviceAddedEventArgs(ev);
        });
    }
}
