using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public sealed class MouseWheelEventArgs : AbstractMouseEventArgs
{
    public MouseWheelDirection Direction { get; }
    public float PreciseX { get; }
    public float PreciseY { get; }

    public MouseWheelEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.MouseWheel )
        {
            throw new InvalidEventTypeException(
                EventType.MouseWheel,
                (EventType)@event.Type
            );
        }

        WindowId = @event.Wheel.WindowID;
        MouseId = @event.Wheel.Which;
        X = @event.Wheel.X;
        Y = @event.Wheel.Y;
        Direction = (MouseWheelDirection)@event.Wheel.Direction;
        PreciseX = @event.Wheel.PreciseX;
        PreciseY = @event.Wheel.PreciseY;
    }
}
