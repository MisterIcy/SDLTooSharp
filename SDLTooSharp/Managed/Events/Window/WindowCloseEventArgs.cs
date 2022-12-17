using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowCloseEventArgs : AbstractWindowEventArgs
{

    public WindowCloseEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.Close )
        {
            throw new ArgumentException("Not a Close event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}
