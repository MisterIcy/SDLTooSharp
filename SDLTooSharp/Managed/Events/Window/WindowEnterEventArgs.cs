using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;
[ExcludeFromCodeCoverage]
public sealed class WindowEnterEventArgs : WindowEventArgs
{

    public WindowEnterEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
