using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowFocusGainedEventArgs : AbstractWindowEventArgs
{

    public WindowFocusGainedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.FocusGained )
        {
            throw new ArgumentException("Not a FocusGained event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}
