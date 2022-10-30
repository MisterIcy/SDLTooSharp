using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowMaximizedEventArgs : WindowEventArgs
{

    public WindowMaximizedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
