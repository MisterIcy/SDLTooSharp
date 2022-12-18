using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Mouse;

public abstract class AbstractMouseEventArgs : AbstractEventArgs
{

    protected uint _windowId;
    protected uint _which;
    protected int _x;
    protected int _y;

    protected AbstractMouseEventArgs(SDL.SDL_Event @event) : base(@event)
    {
    }

    public uint GetWindowID() => _windowId;
    public uint GetMouseID() => _which;
    public int GetX() => _x;
    public int GetY() => _y;
    public Point2 GetPosition() => new Point2(_x, _y);
}
