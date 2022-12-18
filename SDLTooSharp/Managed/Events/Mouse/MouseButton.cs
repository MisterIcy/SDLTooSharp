using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Mouse;

public enum MouseButton : byte
{
    Left = SDL.SDL_BUTTON_LEFT,
    Middle = SDL.SDL_BUTTON_MIDDLE,
    Right = SDL.SDL_BUTTON_RIGHT,
    X1 = SDL.SDL_BUTTON_X1,
    X2 = SDL.SDL_BUTTON_X2
}
