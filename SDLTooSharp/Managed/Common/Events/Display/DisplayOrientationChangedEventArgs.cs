using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Common.Events.Display;

public sealed class DisplayOrientationChangedEventArgs : DisplayEventArgs
{
    public DisplayOrientationChangedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
