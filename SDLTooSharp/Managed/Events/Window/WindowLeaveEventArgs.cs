using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowLeaveEventArgs : AbstractWindowEventArgs
{

    public WindowLeaveEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.Leave )
        {
            throw new ArgumentException("Not a Leave event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}