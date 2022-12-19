using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerDeviceRemovedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerDeviceRemoved;
        ev.CDevice.Which = 1;

        var args = new ControllerDeviceRemovedEventArgs(ev);
        Assert.Equal(EventType.ControllerDeviceRemoved, args.GetType());
        Assert.Equal(1, args.GetControllerID());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerDeviceRemovedEventArgs(ev);
        });
    }
}
