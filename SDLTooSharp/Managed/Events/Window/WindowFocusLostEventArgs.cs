using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public class WindowFocusLostEventArgs : WindowEventArgs
{

    public WindowFocusLostEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
