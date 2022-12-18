using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerAxisMotionEventArgs : AbstractControllerEventArgs
{

    private byte _axis;
    private short _value;

    public ControllerAxisMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerAxisMotion )
        {
            throw new InvalidEventTypeException(
                "ControllerAxisMotion",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _which = @event.CAxis.Which;
        _axis = @event.CAxis.Axis;
        _value = @event.CAxis.Value;
    }

    public byte GetAxisID() => _axis;
    public short GetValue() => _value;
}
