using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Mouse;

public abstract class AbstractMouseEventArgs : AbstractEventArgs
{

    public uint WindowId { get; protected set; }
    public uint MouseId { get; protected set; }
    public int X { get; protected set; }
    public int Y { get; protected set; }

    protected AbstractMouseEventArgs(SDL.SDL_Event @event) : base(@event)
    {
    }
}
