using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Joystick;

public sealed class JoystickBatteryChangedEventArgs : AbstractJoysticEventArgs
{
    public JoystickPowerLevel PowerLevel { get; }
    public JoystickBatteryChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.JoyBatteryUpdated )
        {
            throw new InvalidEventTypeException(
                EventType.JoyBatteryUpdated,
                (EventType)@event.Type
            );
        }

        JoystickId = @event.JBattery.Which;
        PowerLevel = (JoystickPowerLevel)@event.JBattery.Level;
    }
}
