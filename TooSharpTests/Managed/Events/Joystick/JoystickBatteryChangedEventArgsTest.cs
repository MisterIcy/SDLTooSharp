using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Joystick;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Joystick;

public class JoystickBatteryChangedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.JoyBatteryUpdated;
        ev.JBattery.Which = 1;
        ev.JBattery.Level = (SDL.SDL_JoystickPowerLevel)JoystickPowerLevel.Full;

        var args = new JoystickBatteryChangedEventArgs(ev);
        Assert.Equal(EventType.JoyBatteryUpdated, args.Type);
        Assert.Equal(1, args.JoystickId);
        Assert.Equal(JoystickPowerLevel.Full, args.PowerLevel);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new JoystickBatteryChangedEventArgs(ev);
        });
    }
}
