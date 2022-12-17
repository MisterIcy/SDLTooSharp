using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public enum DisplayOrientation
{
    Unknown = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_UNKNOWN,
    Portrait = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT,
    Landscape = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE,
    PortraitFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT_FLIPPED,
    LandscapeFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE_FLIPPED
}
