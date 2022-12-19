using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public abstract class AbstractMouseButtonEventArgs : AbstractMouseEventArgs
{

    public MouseState MouseState { get; protected set; }
    public byte Clicks { get; protected set; }
    public MouseButton Button { get; protected set; }

    protected AbstractMouseButtonEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        WindowId = @event.Button.WindowID;
        Which = @event.Button.Which;
        X = @event.Button.X;
        Y = @event.Button.Y;
        MouseState = new MouseState(@event.Button.State);
        Clicks = @event.Button.Clicks;
        Button = (MouseButton)@event.Button.Button;
    }
}
