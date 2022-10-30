using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Video.Display;

public enum DisplayOrientation
{
    Unknown = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_UNKNOWN,
    Landscape = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE,
    Portrait = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT,
    LandscapeFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE_FLIPPED,
    PortraitFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT_FLIPPED
}
