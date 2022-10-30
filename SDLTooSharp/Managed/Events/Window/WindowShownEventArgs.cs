using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public sealed class WindowShownEventArgs : WindowEventArgs
{

    public WindowShownEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
