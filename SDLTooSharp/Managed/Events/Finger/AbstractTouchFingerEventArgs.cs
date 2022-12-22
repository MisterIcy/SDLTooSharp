using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Finger;

public abstract class AbstractTouchFingerEventArgs : AbstractEventArgs
{
    /// <summary>
    /// Gets the ID of the touch device
    /// </summary>
    public long TouchId { get; }

    /// <summary>
    /// Gets the ID of the finger
    /// </summary>
    public long FingerId { get; }

    /// <summary>
    /// The x-axis location of the event, normalized (0...1)
    /// </summary>
    public float X { get; }

    /// <summary>
    /// The y-axis location of the event, normalized (0...1)
    /// </summary>
    public float Y { get; }

    /// <summary>
    /// The distance in the x axis, normalized (-1...1)
    /// </summary>
    public float DX { get; }

    /// <summary>
    /// The distance in the y axis, normalized (-1...1)
    /// </summary>
    public float DY { get; }

    /// <summary>
    /// The quantity of pressure applied, normalized (0...1)
    /// </summary>
    public float Pressure { get; }

    /// <summary>
    /// The window underneath the finger, if any
    /// </summary>
    public uint WindowId { get; }

    protected AbstractTouchFingerEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        TouchId = @event.TFinger.TouchID;
        FingerId = @event.TFinger.FingerID;
        X = @event.TFinger.X;
        Y = @event.TFinger.Y;
        DX = @event.TFinger.dX;
        DY = @event.TFinger.dY;
        Pressure = @event.TFinger.Pressure;
        WindowId = @event.TFinger.WindowID;
    }
}
