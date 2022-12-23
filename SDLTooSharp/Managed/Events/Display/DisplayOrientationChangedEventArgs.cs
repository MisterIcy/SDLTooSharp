using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayOrientationChangedEventArgs : AbstractDisplayEventArgs
{

    public DisplayOrientationChangedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
