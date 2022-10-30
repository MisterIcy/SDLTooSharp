using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;
[ExcludeFromCodeCoverage]
public abstract class WindowEventArgs : CommonEventArgs
{

    protected WindowEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
