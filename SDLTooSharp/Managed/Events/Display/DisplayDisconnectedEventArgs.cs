using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayDisconnectedEventArgs : AbstractDisplayEventArgs
{

    public DisplayDisconnectedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
