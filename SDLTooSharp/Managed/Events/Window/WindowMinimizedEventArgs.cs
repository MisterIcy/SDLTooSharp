using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;
[ExcludeFromCodeCoverage]
public sealed class WindowMinimizedEventArgs : WindowEventArgs
{

    public WindowMinimizedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
