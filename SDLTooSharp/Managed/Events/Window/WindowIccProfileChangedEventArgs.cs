using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowIccProfileChangedEventArgs : AbstractWindowEventArgs
{

    public WindowIccProfileChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.IccProfileChanged )
        {
            throw new ArgumentException("Not an IccProfileChanged event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}
