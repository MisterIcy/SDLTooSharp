using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowFocusLostEventArgs : AbstractWindowEventArgs
{

    public WindowFocusLostEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.FocusLost )
        {
            throw new ArgumentException("Not a FocusLost event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;

}
