using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Video;

/// <summary>
/// Enumeration of possible display orientations
/// </summary>
public enum DisplayOrientation
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_UNKNOWN,
    /// <summary>
    /// Portrait (longer side is vertical)
    /// </summary>
    Portrait = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT,
    /// <summary>
    /// Landscape (longer side is horizontal)
    /// </summary>
    Landscape = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE,
    /// <summary>
    /// Portrait (up-side down)
    /// </summary>
    PortraitFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT_FLIPPED,
    /// <summary>
    /// Landscape (up-side down)
    /// </summary>
    LandscapeFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE_FLIPPED
}
