using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public sealed class MouseWheelEventArgs : AbstractMouseEventArgs
{
    private MouseWheelDirection _direction;
    private float _preciseX;
    private float _preciseY;

    public MouseWheelEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.MouseWheel )
        {
            throw new InvalidEventTypeException(
                "MouseWheel",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _windowId = @event.Wheel.WindowID;
        _which = @event.Wheel.Which;
        _x = @event.Wheel.X;
        _y = @event.Wheel.Y;
        _direction = (MouseWheelDirection)@event.Wheel.Direction;
        _preciseX = @event.Wheel.PreciseX;
        _preciseY = @event.Wheel.PreciseY;
    }

    public MouseWheelDirection GetDirection() => _direction;
    public Point2 GetScrollingAmount() => base.GetPosition();
    [ExcludeFromCodeCoverage(Justification = "Change of name")]
    private new Point2 GetPosition() => new Point2();

    public Point2F GetPreciseScrollingAmount() => new Point2F(_preciseX, _preciseY);
    public float GetPreciseX() => _preciseX;
    public float GetPreciseY() => _preciseY;
}
