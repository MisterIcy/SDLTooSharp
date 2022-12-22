using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Controller;

public abstract class ControllerTouchPadEventArgs : AbstractControllerEventArgs
{

    public int TouchpadId { get; }
    public int FingerId { get; }
    public float X { get; }
    public float Y { get; }
    public float Pressure { get; }
    protected ControllerTouchPadEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        TouchpadId = @event.CTouchPad.Touchpad;
        ControllerId = @event.CTouchPad.Which;
        FingerId = @event.CTouchPad.Finger;
        X = @event.CTouchPad.X;
        Y = @event.CTouchPad.Y;
        Pressure = @event.CTouchPad.Pressure;

    }
}
