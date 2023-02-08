using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Surface;

namespace SDLTooSharp.Managed.Video.Surface;

/// <summary>
/// Class for SDL Surface
/// </summary>
public partial class SDLSurface : ISurface, IDisposable
{
    /// <summary>
    /// Gets the actual pointer to an <see cref="SDLTooSharp.Bindings.SDL2.SDL.SDL_Surface"/> structure
    /// </summary>
    public IntPtr SurfacePtr { get; protected set; }

    private Size _dimensions;

    /// <summary>
    /// Gets a value that indicates the dimensions of the surface
    /// </summary>
    public Size Dimensions => _dimensions;

    private int _pitch;

    /// <summary>
    /// Gets a value that indicates the pitch of the surface
    /// (i.e. how many pixels there are per row)
    /// </summary>
    public int Pitch => _pitch;

    private IntPtr _pixelPtr;

    /// <summary>
    /// Gets a value that indicates the pointer where the surface's pixels exist
    /// </summary>
    public IntPtr Pixels => _pixelPtr;

    private bool _locked;

    /// <summary>
    /// Gets a value that indicates whether the surface is locked (and thus you can write to its pixels)
    /// </summary>
    public bool IsLocked => _locked;

    /// <summary>
    /// Gets or sets a value that indicates the Surface's color key.
    /// </summary>
    /// <remarks>For implementation details, check <see cref="SDL.SDL_GetColorKey">SDL_GetColorKey</see>,
    /// <see cref="SDL.SDL_HasColorKey">HasColorKey</see> and <see cref="SDL.SDL_SetColorKey">SetColorKey</see>
    /// </remarks>
    /// <exception cref="UnableToGetSurfaceColorKeyException">In case we cannot get the surface color key</exception>
    /// <exception cref="UnableToSetSurfaceColorKeyException">In case we cannot set the surface color key</exception>
    public Color? ColorKey
    {
        get {
            var hasKey = SDL.SDL_HasColorKey(SurfacePtr);
            if ( !hasKey )
            {
                return null;
            }

            int result = SDL.SDL_GetColorKey(SurfacePtr, out uint color);

            if ( result != 0 )
            {
                throw new UnableToGetSurfaceColorKeyException();
            }

            return new Color(color);
        }
        set {
            int enable = value != null ? 1 : 0;
            uint color = value == null ? 0 : (uint)value;

            int result = SDL.SDL_SetColorKey(SurfacePtr, enable, color);
            if ( result != 0 )
            {
                throw new UnableToSetSurfaceColorKeyException();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates a color value that gets multiplied into blit operations
    /// </summary>
    /// <remarks>
    /// For implementation details see <see cref="SDL.SDL_GetSurfaceColorMod">SDL_GetSurfaceColorMod</see> and
    /// <see cref="SDL.SDL_SetSurfaceColorMod">SDL_SetSurfaceColorMod</see>
    /// </remarks>
    /// <exception cref="UnableToGetSurfaceColorModException">In case we are not able to get the surface's color mod</exception>
    /// <exception cref="UnableToSetSurfaceColorModException">In case we are not able to set the surface's color mod</exception>
    public Color? ColorMod
    {
        get {
            int result = SDL.SDL_GetSurfaceColorMod(SurfacePtr, out byte r, out byte g, out byte b);
            if ( result != 0 )
            {
                throw new UnableToGetSurfaceColorModException();
            }

            return new Color(r, g, b);
        }
        set {
            value ??= new Color(255, 255, 255);

            int result = SDL.SDL_SetSurfaceColorMod(SurfacePtr, value.R, value.G, value.B);
            if ( result != 0 )
            {
                throw new UnableToSetSurfaceColorModException();
            }
        }
    }

    /// <summary>
    /// Sets or gets a value which indicates the alpha component to be multiplied in blit operations
    /// </summary>
    /// <remarks>For implementation details check <see cref="SDL.SDL_GetSurfaceAlphaMod"/>
    /// and <see cref="SDL.SDL_SetSurfaceAlphaMod"/></remarks>
    /// <exception cref="UnableToGetSurfaceAlphaModException"/>
    /// <exception cref="UnableToSetSurfaceAlphaModException"/>
    public byte AlphaMod
    {
        get {
            int result = SDL.SDL_GetSurfaceAlphaMod(SurfacePtr, out byte alpha);
            if ( result != 0 )
            {
                throw new UnableToGetSurfaceAlphaModException();
            }

            return alpha;
        }
        set {
            int result = SDL.SDL_SetSurfaceAlphaMod(SurfacePtr, value);
            if ( result != 0 )
            {
                throw new UnableToSetSurfaceAlphaModException();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates the surface's blend mode.
    /// </summary>
    /// <exception cref="UnableToGetSurfaceBlendModeException"></exception>
    /// <exception cref="UnableToSetSurfaceBlendModeException"></exception>
    public SDL.SDL_BlendMode BlendMode
    {
        get {
            int result = SDL.SDL_GetSurfaceBlendMode(SurfacePtr, out var mode);
            if ( result != 0 )
            {
                throw new UnableToGetSurfaceBlendModeException();
            }

            return mode;
        }
        set {
            int result = SDL.SDL_SetSurfaceBlendMode(SurfacePtr, value);
            if ( result != 0 )
            {
                throw new UnableToSetSurfaceBlendModeException();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value which indicates whether the surface is RLE-enabled.
    /// </summary>
    /// <exception cref="UnableToSetRLEException"></exception>
    public bool RLE
    {
        get => SDL.SDL_HasSurfaceRLE(SurfacePtr);
        set {
            int flag = value ? 1 : 0;

            int result = SDL.SDL_SetSurfaceRLE(SurfacePtr, flag);
            if ( result != 0 )
            {
                throw new UnableToSetRLEException(value);
            }
        }
    }


    /// <summary>
    /// Set up a surface for directly accessing the pixels.
    /// </summary>
    public void Lock()
    {
        if ( _locked )
        {
            return;
        }

        int result = SDL.SDL_LockSurface(SurfacePtr);
        if ( result != 0 )
        {
            throw new UnableToLockSurfaceException();
        }

        _locked = true;
    }

    /// <summary>
    /// Release a surface after directly accessing the pixels.
    /// </summary>
    public void Unlock()
    {
        if ( !_locked )
        {
            return;
        }

        SDL.SDL_UnlockSurface(SurfacePtr);
        _locked = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <param name="depth"></param>
    /// <param name="rMask"></param>
    /// <param name="gMask"></param>
    /// <param name="bMask"></param>
    /// <param name="aMask"></param>
    public SDLSurface(Size size,
        SurfaceDepth depth = SurfaceDepth.D32BPP,
        uint rMask = 0xff000000,
        uint gMask = 0x00ff0000,
        uint bMask = 0x0000ff00,
        uint aMask = 0x000000ff)
    {
        SurfacePtr = SDL.SDL_CreateRGBSurface(0, size.Width, size.Height, (int)depth, rMask, gMask, bMask, aMask);

        if ( SurfacePtr == IntPtr.Zero )
        {
            throw new UnableToCreateSurfaceException();
        }

        InitializeSurface();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <param name="depth"></param>
    /// <param name="format"></param>
    public SDLSurface(Size size, SurfaceDepth depth = SurfaceDepth.D32BPP,
        SDL.SDL_PixelFormatEnum format = SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA8888)
    {
        SurfacePtr = SDL.SDL_CreateRGBSurfaceWithFormat(
            0, size.Width, size.Height, (int)depth, (uint)format);

        if ( SurfacePtr == IntPtr.Zero )
        {
            throw new UnableToCreateSurfaceException();
        }

        InitializeSurface();
    }

    private void InitializeSurface()
    {
        SDL.SDL_Surface srf = Marshal.PtrToStructure<SDL.SDL_Surface>(SurfacePtr);

        _dimensions = new Size(srf.W, srf.H);
        _pitch = srf.Pitch;
        _pixelPtr = srf.Pixels;
    }

    ~SDLSurface()
    {
        Dispose(false);
    }

    private void ReleaseUnmanagedResources()
    {
        if ( SurfacePtr == IntPtr.Zero )
        {
            return;
        }

        SDL.SDL_FreeSurface(SurfacePtr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if ( disposing )
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="surfacePtr"></param>
    private SDLSurface(IntPtr surfacePtr)
    {
        SurfacePtr = surfacePtr;
        if ( SurfacePtr == IntPtr.Zero )
        {
            throw new UnableToCreateSurfaceException();
        }
        InitializeSurface();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public SDLSurface Duplicate()
    {
        IntPtr surfacePtr = SDL.SDL_DuplicateSurface(SurfacePtr);
        if ( surfacePtr == IntPtr.Zero )
        {
            throw new UnableToDuplicateSurfaceException();
        }

        return new SDLSurface(surfacePtr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    public SDLSurface Convert(uint format)
    {
        IntPtr surfacePtr = SDL.SDL_ConvertSurfaceFormat(SurfacePtr, format, 0);
        if ( surfacePtr == IntPtr.Zero )
        {
            throw new UnableToConvertSurfaceException();
        }

        return new SDLSurface(surfacePtr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public SDLSurface Covnert(IntPtr format) =>
        throw new NotImplementedException("SDL_ConvertSurface is not implemented");
}
