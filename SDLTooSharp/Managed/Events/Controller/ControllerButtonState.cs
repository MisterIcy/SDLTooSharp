using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Controller;

public enum ControllerButtonState : byte
{
    Pressed = SDL.SDL_PRESSED,
    Released = SDL.SDL_RELEASED
}
