using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowMovedEventArgs : AbstractWindowEventArgs
{

    public WindowMovedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.Moved )
        {
            throw new ArgumentException("Not a Moved event", nameof(@event));
        }
    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;

    public Point2 GetPosition()
    {
        return new Point2(base.GetData1(), base.GetData2());
    }
}
