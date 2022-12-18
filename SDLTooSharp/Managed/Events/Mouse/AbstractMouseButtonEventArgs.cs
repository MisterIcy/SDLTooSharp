using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Mouse;

public abstract class AbstractMouseButtonEventArgs : AbstractMouseEventArgs
{

    private MouseState _mouseState;
    private byte _clicks;
    private MouseButton _button;

    protected AbstractMouseButtonEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type is not ( (uint)EventType.MouseButtonDown or (uint)EventType.MouseButtonUp ) )
        {
            throw new InvalidEventTypeException(
                "MouseButton",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _windowId = @event.Button.WindowID;
        _which = @event.Button.Which;
        _x = @event.Button.X;
        _y = @event.Button.Y;
        _mouseState = new MouseState(@event.Button.State);
        _clicks = @event.Button.Clicks;
        _button = (MouseButton)@event.Button.Button;
    }

    public virtual MouseState GetMouseState() => _mouseState;
    public virtual byte GetClicks() => _clicks;
    public virtual MouseButton GetMouseButton() => _button;
}
