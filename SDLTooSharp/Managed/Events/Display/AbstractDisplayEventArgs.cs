using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public abstract class AbstractDisplayEventArgs : AbstractSdlEventArgs
{
    public uint DisplayId { get; protected set; }
    public int Data { get; protected set; }

    protected AbstractDisplayEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        DisplayId = ev.Display.Display;
        Data = ev.Display.Data1;
    }
}
