using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public sealed class MouseMotionEventArgs : AbstractMouseEventArgs
{

    public int RelativeX { get; }
    public int RelativeY { get; }
    public MouseState MouseState { get; }

    public MouseMotionEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.MouseMotion )
        {
            throw new InvalidEventTypeException(
                EventType.MouseMotion,
                (EventType)@event.Type
            );
        }

        WindowId = @event.Motion.WindowID;
        MouseId = @event.Motion.Which;
        X = @event.Motion.X;
        Y = @event.Motion.Y;
        RelativeX = @event.Motion.XRel;
        RelativeY = @event.Motion.YRel;
        MouseState = new MouseState(@event.Motion.State);
    }
}
