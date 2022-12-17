using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowTakeFocusEventArgs : AbstractWindowEventArgs
{

    public WindowTakeFocusEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.TakeFocus )
        {
            throw new ArgumentException("Not a TakeFocus event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}
