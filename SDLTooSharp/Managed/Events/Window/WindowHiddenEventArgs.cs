using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowHiddenEventArgs : AbstractWindowEventArgs
{

    public WindowHiddenEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.Hidden )
        {
            throw new ArgumentException("Not a Hidden event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}
