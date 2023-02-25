using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Bindings.SDL2Image;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Texture;
using SDLTooSharp.Managed.Video.Renderer;
using SDLTooSharp.Managed.Video.Surface;

namespace SDLTooSharp.Managed.Video.Texture;

public class SDLTexture : IDisposable
{
    public IntPtr TexturePtr { get; protected set; }

    public SDLRenderer Renderer { get; protected init; }

    public SDLTexture(SDLRenderer renderer, ISurface surface)
    {
        TexturePtr = SDL.SDL_CreateTextureFromSurface(
            renderer.RendererPtr,
            surface.SurfacePtr);

        if ( TexturePtr == IntPtr.Zero )
        {
            throw new UnableToCreateTextureException();
        }

        Renderer = renderer;
    }

    public SDLTexture(Size size, SDLRenderer renderer, uint format, int access)
    {
        TexturePtr = SDL.SDL_CreateTexture(
            renderer.RendererPtr,
            format,
            access,
            size.Width,
            size.Height
        );

        if ( TexturePtr == IntPtr.Zero )
        {
            throw new UnableToCreateTextureException();
        }

        Renderer = renderer;
    }
    private Color? _colorMod;
    public Color ColorMod
    {
        get {
            if ( _colorMod != null )
            {
                return _colorMod;
            }

            int result = SDL.SDL_GetTextureColorMod(TexturePtr, out byte r, out byte g, out byte b);
            if ( result != 0 )
            {
                throw new UnableToGetTextureColorModException();
            }

            _colorMod = new Color(r, g, b);
            return _colorMod;
        }
        set {
            if ( _colorMod == value )
            {
                return;
            }

            int result = SDL.SDL_SetTextureColorMod(TexturePtr, value.R, value.G, value.B);
            if ( result != 0 )
            {
                throw new UnableToSetTextureColorModException();
            }
        }
    }

    public byte AlphaMod
    {
        get {
            int result = SDL.SDL_GetTextureAlphaMod(TexturePtr, out byte a);
            if ( result != 0 )
            {
                throw new UnableToGetTextureAlphaModException();
            }

            return a;
        }
        set {
            int result = SDL.SDL_SetTextureAlphaMod(TexturePtr, value);
            if ( result != 0 )
            {
                throw new UnableToSetTextureAlphaModException();
            }
        }
    }

    public SDL.SDL_BlendMode BlendMode
    {
        get {
            int result = SDL.SDL_GetTextureBlendMode(TexturePtr, out var mode);
            if ( result != 0 )
            {
                throw new UnableToGetTextureBlendModeException();
            }

            return mode;
        }
        set {
            int result = SDL.SDL_SetTextureBlendMode(TexturePtr, value);
            if ( result != 0 )
            {
                throw new UnableToSetTextureBlendModeException();
            }
        }
    }

    public SDL.SDL_ScaleMode ScaleMode
    {
        get {
            int result = SDL.SDL_GetTextureScaleMode(TexturePtr, out var mode);
            if ( result != 0 )
            {
                throw new UnableToGetTextureScaleModeException();
            }

            return mode;
        }
        set {
            int result = SDL.SDL_SetTextureScaleMode(TexturePtr, value);
            if ( result != 0 )
            {
                throw new UnableToSetTextureScaleModeException();
            }
        }
    }

    public SDLTexture(SDLRenderer renderer, string filename, Color colorKey)
    {
        if ( !File.Exists(filename) )
        {
            throw new FileNotFoundException("File not found", filename);
        }

        var surface = SDLSurface.FromImageFile(filename);

        var newSurface = surface.Convert((uint)SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA8888);
        surface.Dispose();
        newSurface.ColorKey = colorKey;

        TexturePtr = SDL.SDL_CreateTextureFromSurface(renderer.RendererPtr, newSurface.SurfacePtr);
        if ( TexturePtr == IntPtr.Zero )
        {
            newSurface.Dispose();
            throw new UnableToCreateTextureException();
        }

        newSurface.Dispose();
        Renderer = renderer;

    }
    /// <summary>
    /// Create a new texture from a file
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="filename"></param>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="UnableToCreateTextureException"></exception>
    public SDLTexture(SDLRenderer renderer, string filename)
    {
        if ( !File.Exists(filename) )
        {
            throw new FileNotFoundException("File not found", filename);
        }

        TexturePtr = SDLImage.IMG_LoadTexture(renderer.RendererPtr, filename);

        if ( TexturePtr == IntPtr.Zero )
        {
            throw new UnableToCreateTextureException();
        }

        Renderer = renderer;
    }
    private void ReleaseUnmanagedResources()
    {
        if ( TexturePtr != IntPtr.Zero )
        {
            SDL.SDL_DestroyTexture(TexturePtr);
        }
    }
    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if ( disposing )
        {

        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ~SDLTexture()
    {
        Dispose(false);
    }
}
