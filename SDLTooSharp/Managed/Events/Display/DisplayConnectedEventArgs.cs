using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayConnectedEventArgs : DisplayEventArgs
{

    public DisplayConnectedEventArgs(SDL.SDL_Event ev) : base(ev)
    {

    }
}
