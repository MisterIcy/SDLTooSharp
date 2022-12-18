using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Controller;

public abstract class ControllerTouchPadEventArgs : AbstractControllerEventArgs
{

    private int _touchpadID;
    private int _fingerId;
    private float _x;
    private float _y;
    private float _pressure;
    protected ControllerTouchPadEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        _which = @event.CTouchPad.Which;
        _fingerId = @event.CTouchPad.Finger;
        _x = @event.CTouchPad.X;
        _y = @event.CTouchPad.Y;
        _pressure = @event.CTouchPad.Pressure;

    }

    public int GetFingerId() => _fingerId;
    public float GetX() => _x;
    public float GetY() => _y;
    public Point2F GetPoint() => new Point2F(GetX(), GetY());
    public float GetPressure() => _pressure;
}
