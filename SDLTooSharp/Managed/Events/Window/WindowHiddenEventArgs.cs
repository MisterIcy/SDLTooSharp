using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public sealed class WindowHiddenEventArgs : WindowEventArgs
{

    public WindowHiddenEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
