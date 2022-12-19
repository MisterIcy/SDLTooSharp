using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerSensorUpdatedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerSensorUpdate;
        ev.CSensor.Which = 1;
        ev.CSensor.Sensor = 1;

        var args = new ControllerSensorUpdatedEventArgs(ev);
        Assert.Equal(EventType.ControllerSensorUpdate, args.Type);
        Assert.Equal(1, args.Which);
        Assert.Equal(1, args.SensorId);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerSensorUpdatedEventArgs(ev);
        });
    }
}
