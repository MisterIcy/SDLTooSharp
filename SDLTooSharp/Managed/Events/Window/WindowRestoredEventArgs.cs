using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowRestoredEventArgs : AbstractWindowEventArgs
{

    public WindowRestoredEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.Restored )
        {
            throw new ArgumentException("Not a Restored event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;

}
