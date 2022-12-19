using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Controller;

public sealed class ControllerAxisMotionEventArgs : AbstractControllerEventArgs
{

    /// <summary>
    /// The Id of the axis
    /// </summary>
    public byte Axis
    {
        get;
    }

    /// <summary>
    /// The value of the axis
    /// </summary>
    public short Value
    {
        get;
    }

    public ControllerAxisMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.ControllerAxisMotion )
        {
            throw new InvalidEventTypeException(
                EventType.ControllerAxisMotion,
                (EventType)@event.Type
            );
        }

        Which = @event.CAxis.Which;
        Axis = @event.CAxis.Axis;
        Value = @event.CAxis.Value;
    }
}
