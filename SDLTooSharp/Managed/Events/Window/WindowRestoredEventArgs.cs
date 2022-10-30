using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowRestoredEventArgs : WindowEventArgs
{

    public WindowRestoredEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
