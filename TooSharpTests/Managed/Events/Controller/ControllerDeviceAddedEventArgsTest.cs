using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerDeviceAddedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerDeviceAdded;
        ev.CDevice.Which = 1;

        var args = new ControllerDeviceAddedEventArgs(ev);
        Assert.Equal(EventType.ControllerDeviceAdded, args.Type);
        Assert.Equal(1, args.ControllerId);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerDeviceAddedEventArgs(ev);
        });
    }
}
