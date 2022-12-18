using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickBatteryChangedEventArgs : AbstractJoysticEventArgs
{
    private JoystickPowerLevel _powerLevel;
    public JoystickBatteryChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyBatteryUpdated )
        {
            throw new InvalidEventTypeException(
                "JoyBatteryUpdated",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _which = @event.JBattery.Which;
        _powerLevel = (JoystickPowerLevel)@event.JBattery.Level;
    }

    public JoystickPowerLevel GetPowerLevel() => _powerLevel;
}
