using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Bindings.SDL2Image;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Video.Surface;

public partial class SDLSurface : ISurface, IDisposable
{
    /// <summary>
    /// The actual pointer to an <see cref="SDLTooSharp.Bindings.SDL2.SDL.SDL_Surface"/> structure
    /// </summary>
    public IntPtr SurfacePtr { get; protected set; }

    private Size _dimesnions;

    public Size Dimensions => _dimesnions;

    private int _pitch;
    public int Pitch => _pitch;

    private IntPtr _pixelPtr;
    public IntPtr Pixels => _pixelPtr;
    private bool _locked = false;
    public bool IsLocked => _locked;

    public Color? ColorKey
    {
        get {
            var hasKey = SDL.SDL_HasColorKey(SurfacePtr);
            if ( !hasKey )
            {
                ;
                return null;
            }

            int result = SDL.SDL_GetColorKey(SurfacePtr, out uint color);

            if ( result != 0 )
            {
                //TODO: Cannot get color key, throw
            }

            return new Color(color);
        }
        set {
            int enable = value != null ? 1 : 0;
            uint color = value == null ? 0 : (uint)value;

            int result = SDL.SDL_SetColorKey(SurfacePtr, enable, color);
            if ( result != 0 )
            {
                //TODO: Cannot set color key, thow
            }
        }
    }

    public Color? ColorMod
    {
        get {
            int result = SDL.SDL_GetSurfaceColorMod(SurfacePtr, out byte r, out byte g, out byte b);
            if ( result != 0 )
            {
                // TODO: Cannot get color mod, throw
            }

            return new Color(r, g, b);
        }
        set {
            value ??= new Color(255, 255, 255);

            int result = SDL.SDL_SetSurfaceColorMod(SurfacePtr, value.R, value.G, value.B);
            if ( result != 0 )
            {
                //TODO: cannot set color mod, throw
            }
        }
    }

    public byte AlphaMod
    {
        get {
            int result = SDL.SDL_GetSurfaceAlphaMod(SurfacePtr, out byte alpha);
            if ( result != 0 )
            {
                //TODO: cannot get alpha mod, throw
            }

            return alpha;
        }
        set {
            int result = SDL.SDL_SetSurfaceAlphaMod(SurfacePtr, value);
            if ( result != 0 )
            {
                //TODO: cannot set alpha mod, throw
            }
        }
    }

    public SDL.SDL_BlendMode BlendMode
    {
        get {
            int result = SDL.SDL_GetSurfaceBlendMode(SurfacePtr, out var mode);
            if ( result != 0 )
            {
                // TODO: cannot get blend mode, throw
            }

            return mode;
        }
        set {
            int result = SDL.SDL_SetSurfaceBlendMode(SurfacePtr, value);
            if ( result != 0 )
            {
                //TODO: cannot set blend mode, throw
            }
        }
    }
    public bool RLE
    {
        get => SDL.SDL_HasSurfaceRLE(SurfacePtr);
        set {
            int result;

            if ( value )
            {
                result = SDL.SDL_SetSurfaceRLE(SurfacePtr, 1);

                if ( result != 0 )
                {
                    //TODO: Cannot enable RLE, throw
                }

                return;
            }

            result = SDL.SDL_SetSurfaceRLE(SurfacePtr, 0);
            if ( result != 0 )
            {
                //TODO: Cannot disable RLE, throw
            }
        }
    }


    public void Lock()
    {
        if ( _locked )
        {
            return;
        }

        int result = SDL.SDL_LockSurface(SurfacePtr);
        if ( result != 0 )
        {
            //TODO: Cannot lock, throw
        }

        _locked = true;
    }

    public void Unlock()
    {
        if ( !_locked )
        {
            return;
        }

        SDL.SDL_UnlockSurface(SurfacePtr);
        _locked = false;
    }

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
            //TODO: Throw
        }

        InitializeSurface();
    }

    public SDLSurface(Size size, SurfaceDepth depth = SurfaceDepth.D32BPP,
        SDL.SDL_PixelFormatEnum format = SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA8888)
    {
        SurfacePtr = SDL.SDL_CreateRGBSurfaceWithFormat(
            0, size.Width, size.Height, (int)depth, (uint)format);

        if ( SurfacePtr == IntPtr.Zero )
        {
            //TODO: Throw
        }

        InitializeSurface();
    }

    private void InitializeSurface()
    {
        SDL.SDL_Surface srf = Marshal.PtrToStructure<SDL.SDL_Surface>(SurfacePtr);

        _dimesnions = new Size(srf.W, srf.H);
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

    private SDLSurface(IntPtr surfacePtr)
    {
        SurfacePtr = surfacePtr;
        InitializeSurface();
    }

    public SDLSurface Duplicate()
    {
        IntPtr surfacePtr = SDL.SDL_DuplicateSurface(SurfacePtr);
        if ( surfacePtr == IntPtr.Zero )
        {
            //TODO: Cannot duplicate, throw
        }

        return new SDLSurface(surfacePtr);
    }

    public SDLSurface Convert(uint format)
    {
        IntPtr surfacePtr = SDL.SDL_ConvertSurfaceFormat(SurfacePtr, format, 0);
        if ( surfacePtr == IntPtr.Zero )
        {
            //TODO: Cannot convert to format, throw
        }

        return new SDLSurface(surfacePtr);
    }

    public SDLSurface Covnert(IntPtr format) => throw new NotImplementedException("SDL_ConvertSurface is not implemented");


}
