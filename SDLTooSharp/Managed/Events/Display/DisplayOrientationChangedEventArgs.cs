using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Video.Display;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayOrientationChangedEventArgs : DisplayEventArgs
{
    public DisplayOrientation NewOrientation { get; }
    public DisplayOrientationChangedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        NewOrientation = (DisplayOrientation)ev.Display.Data1;
    }
}
