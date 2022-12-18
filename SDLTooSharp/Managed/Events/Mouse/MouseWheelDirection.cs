using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Mouse;

public enum MouseWheelDirection
{
    Normal = SDL.SDL_MouseWheelDirection.SDL_MOUSEWHEEL_NORMAL,
    Flipped = SDL.SDL_MouseWheelDirection.SDL_MOUSEWHEEL_FLIPPED
}
