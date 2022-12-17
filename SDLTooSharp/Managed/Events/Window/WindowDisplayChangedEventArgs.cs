using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowDisplayChangedEventArgs : AbstractWindowEventArgs
{

    public WindowDisplayChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.DisplayChanged )
        {
            throw new ArgumentException("Not a DisplayChanged event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
    public int GetDisplayId() => base.GetData1();
}
