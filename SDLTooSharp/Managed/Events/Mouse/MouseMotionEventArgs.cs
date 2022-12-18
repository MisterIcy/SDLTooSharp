using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public sealed class MouseMotionEventArgs : AbstractMouseEventArgs
{

    private int _xrel;
    private int _yrel;
    private MouseState _state;

    public MouseMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.MouseMotion )
        {
            throw new InvalidEventTypeException(
                "MouseMotion",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _windowId = @event.Motion.WindowID;
        _which = @event.Motion.Which;
        _x = @event.Motion.X;
        _y = @event.Motion.Y;
        _xrel = @event.Motion.XRel;
        _yrel = @event.Motion.YRel;
        _state = new MouseState(@event.Motion.State);
    }

    public MouseState GetMouseState() => _state;
    public Point2 GetRelativeMotion() => new Point2(_xrel, _yrel);
    public int GetRelativeX() => _xrel;
    public int GetRelativeY() => _yrel;
}
