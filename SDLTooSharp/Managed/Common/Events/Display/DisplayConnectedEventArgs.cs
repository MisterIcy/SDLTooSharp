using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Common.Events.Display;

public sealed class DisplayConnectedEventArgs : DisplayEventArgs
{

    public DisplayConnectedEventArgs(SDL.SDL_Event ev) : base(ev)
    {

    }
}
