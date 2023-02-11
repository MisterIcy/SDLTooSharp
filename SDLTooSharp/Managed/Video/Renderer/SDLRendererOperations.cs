using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Renderer;
using SDLTooSharp.Managed.Video.Texture;

namespace SDLTooSharp.Managed.Video.Renderer;

public abstract partial class SDLRenderer
{
    public void Copy(
        SDLTexture texture,
        Rectangle source,
        Rectangle destination
    )
    {
        int result = SDL.SDL_RenderCopy(
            RendererPtr, texture.TexturePtr, (SDL.SDL_Rect)source, (SDL.SDL_Rect)destination
        );

        if ( result != 0 )
        {
            throw new DrawOperationFailedException("Copy");
        }
    }

    public void CopyEx(
        SDLTexture texture,
        Rectangle source,
        Rectangle destination,
        double angle,
        Point2 center,
        SDL.SDL_RendererFlip flip
    )
    {
        int result = SDL.SDL_RenderCopyEx(
            RendererPtr,
            texture.TexturePtr,
            (SDL.SDL_Rect)source,
            (SDL.SDL_Rect)destination,
            angle,
            (SDL.SDL_Point)center,
            flip);

        if ( result != 0 )
        {
            throw new DrawOperationFailedException("CopyEx");
        }
    }

}
