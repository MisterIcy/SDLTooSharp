using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Video.Renderer;
using SDLTooSharp.Managed.Video.Surface;

namespace SDLTooSharp.Managed.Video.Texture;

public class SDLTexture
{
    public IntPtr TexturePtr { get; protected set; }

    public SDLRenderer Renderer { get; protected init; }

    public SDLTexture(SDLRenderer renderer, SDLSurface surface)
    {
        TexturePtr = SDL.SDL_CreateTextureFromSurface(
            renderer.RendererPtr,
            surface.SurfacePtr);

        if ( TexturePtr == IntPtr.Zero )
        {
            //TODO: Throw
        }
    }
}
