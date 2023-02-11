using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Video.Surface;

namespace SDLTooSharp.Managed.Video.Renderer;

/// <summary>
/// Software renderer, rendering on surfaces
/// </summary>
public class SDLSoftwareRenderer : SDLRenderer
{
    /// <summary>
    /// A pointer to the surface
    /// </summary>
    public SDLSurface Surface { get; protected set; }

    /// <summary>
    /// Creates a new SoftwareRenderer
    /// </summary>
    /// <param name="surface"></param>
    public SDLSoftwareRenderer(SDLSurface surface)
    {
        RendererPtr = SDL.SDL_CreateSoftwareRenderer(surface.SurfacePtr);
        if ( RendererPtr == IntPtr.Zero )
        {
            //TODO: Throw
        }

        Surface = surface;
    }
}
