using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Keyboard;

public sealed class KeyUpEventArgs : KeyboardEventArgs
{

    public KeyUpEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
