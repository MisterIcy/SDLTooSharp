using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowSizeChangedEventArgs : AbstractWindowEventArgs
{

    public WindowSizeChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.SizeChanged )
        {
            throw new ArgumentException("Not a SizeChanged event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;

    public Size GetSize()
    {
        return new Size(base.GetData1(), base.GetData2());
    }
}
