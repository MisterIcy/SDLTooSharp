using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Video.Display;

namespace SDLTooSharp.Managed.Events.Display;
[ExcludeFromCodeCoverage]
public sealed class DisplayOrientationChangedEventArgs : DisplayEventArgs
{
    public DisplayOrientation NewOrientation { get; }
    public DisplayOrientationChangedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        NewOrientation = (DisplayOrientation)ev.Display.Data1;
    }
}
