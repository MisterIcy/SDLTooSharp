using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Bindings.SDL2Image;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Surface;

namespace SDLTooSharp.Managed.Video.Surface;

/// <summary>
/// Class for SDL Surface
/// </summary>
[ExcludeFromCodeCoverage]
public partial class SDLSurface : ISurface
{
    /// <inheritdoc cref="SurfacePtr"/>
    public IntPtr SurfacePtr { get; init; }

    private Size _dimensions;

    /// <inheritdoc cref="Dimensions"/>
    public Size Dimensions => _dimensions;

    private int _pitch;

    /// <inheritdoc cref="Pitch"/>
    public int Pitch => _pitch;

    private IntPtr _pixelPtr;

    /// <inheritdoc cref="Pixels"/>
    public IntPtr Pixels => _pixelPtr;

    private bool _locked;

    /// <inheritdoc cref="IsLocked"/>
    public bool IsLocked => _locked;

    /// <inheritdoc cref="ColorKey"/>
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

    /// <inheritdoc cref="ColorMod"/>
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

    /// <inheritdoc cref="AlphaMod"/>
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

    /// <inheritdoc cref="BlendMode"/>
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

    /// <inheritdoc cref="RLE"/>
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


    /// <inheritdoc cref="Lock"/>
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

    /// <inheritdoc cref="Unlock"/>
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
        SurfaceDepth depth = SurfaceDepth.Depth32BitPerPixel,
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
    public SDLSurface(Size size, SurfaceDepth depth = SurfaceDepth.Depth32BitPerPixel,
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
    public SDLSurface(IntPtr surfacePtr)
    {
        SurfacePtr = surfacePtr;
        if ( SurfacePtr == IntPtr.Zero )
        {
            throw new UnableToCreateSurfaceException();
        }

        InitializeSurface();
    }

    /// <inheritdoc cref="Duplicate"/>
    public ISurface Duplicate()
    {
        IntPtr surfacePtr = SDL.SDL_DuplicateSurface(SurfacePtr);
        if ( surfacePtr == IntPtr.Zero )
        {
            throw new UnableToDuplicateSurfaceException();
        }

        return new SDLSurface(surfacePtr);
    }

    /// <inheritdoc cref="Convert"/>
    public ISurface Convert(uint format)
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
    public ISurface Covnert(IntPtr format) =>
        throw new NotImplementedException("SDL_ConvertSurface is not implemented");

    public static ISurface FromImageFile(string file)
    {
        if ( !File.Exists(file) )
        {
            throw new FileNotFoundException("Image file was not found", file);
        }

        IntPtr surfacePtr = SDLImage.IMG_Load(file);

        if ( surfacePtr == IntPtr.Zero )
        {
            //TODO: Throw
        }

        return new SDLSurface(surfacePtr);
    }
}
