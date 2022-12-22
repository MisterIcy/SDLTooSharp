using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickAxisMotionEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyAxisMotion;
        ev.JAxis.Which = 1;
        ev.JAxis.Axis = 1;
        ev.JAxis.Value = 42;

        var args = new JoystickAxisMotionEventArgs(ev);
        Assert.Equal(EventType.JoyAxisMotion, args.Type);
        Assert.Equal(1, args.Which);
        Assert.Equal(1, args.AxisID);
        Assert.Equal(42, args.Value);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickAxisMotionEventArgs(ev);
        });
    }
}
