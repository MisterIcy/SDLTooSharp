using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public class WindowFocusGainedEventArgs : WindowEventArgs
{

    public WindowFocusGainedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
