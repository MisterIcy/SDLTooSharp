using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Video.Surface;

namespace SDLTooSharp.Managed.Video.Renderer;

public class SDLSoftwareRenderer : SDLRenderer
{
    public SDLSurface Surface { get; protected set; }

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
