using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Keyboard;

public enum KeyState
{
    Pressed = SDL.SDL_PRESSED,
    Released = SDL.SDL_RELEASED
}
