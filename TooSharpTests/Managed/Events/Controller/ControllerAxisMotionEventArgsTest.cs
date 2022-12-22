using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerAxisMotionEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerAxisMotion;
        ev.CAxis.Which = 1;
        ev.CAxis.Axis = 1;
        ev.CAxis.Value = 42;

        var args = new ControllerAxisMotionEventArgs(ev);
        Assert.Equal(EventType.ControllerAxisMotion, args.Type);
        Assert.Equal(1, args.ControllerId);
        Assert.Equal(1, args.AxisId);
        Assert.Equal(42, args.Value);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerAxisMotionEventArgs(ev);
        });
    }
}
