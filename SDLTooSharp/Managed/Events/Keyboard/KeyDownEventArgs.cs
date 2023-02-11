using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Keyboard;

public sealed class KeyDownEventArgs : KeyboardEventArgs
{

    public KeyDownEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
