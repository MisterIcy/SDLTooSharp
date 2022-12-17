using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowShownEventArgs: AbstractWindowEventArgs
{
    public WindowShownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.Shown )
        {
            throw new ArgumentException("Not a Shown event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}
