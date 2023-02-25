using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Surface;

namespace SDLTooSharp.Managed.Video.Surface;

/// <summary>
/// Interface for surfaces
/// </summary>
public interface ISurface : IDisposable
{
    /// <summary>
    /// Gets the actual pointer to an <see cref="SDLTooSharp.Bindings.SDL2.SDL.SDL_Surface"/> structure
    /// </summary>
    public IntPtr SurfacePtr { get; init; }
    /// <summary>
    /// Gets a value that indicates the dimensions of the surface
    /// </summary>
    public Size Dimensions { get; }

    /// <summary>
    /// Gets a value that indicates the pitch of the surface
    /// (i.e. how many pixels there are per row)
    /// </summary>
    public int Pitch { get; }

    /// <summary>
    /// Gets a value that indicates the pointer where the surface's pixels exist
    /// </summary>
    public IntPtr Pixels { get; }

    /// <summary>
    /// Gets a value that indicates whether the surface is locked (and thus you can write to its pixels)
    /// </summary>
    public bool IsLocked { get; }

    /// <summary>
    /// Gets or sets a value that indicates the Surface's color key.
    /// </summary>
    /// <remarks>For implementation details, check <see cref="SDL.SDL_GetColorKey">SDL_GetColorKey</see>,
    /// <see cref="SDL.SDL_HasColorKey">HasColorKey</see> and <see cref="SDL.SDL_SetColorKey">SetColorKey</see>
    /// </remarks>
    /// <exception cref="UnableToGetSurfaceColorKeyException">In case we cannot get the surface color key</exception>
    /// <exception cref="UnableToSetSurfaceColorKeyException">In case we cannot set the surface color key</exception>
    public Color? ColorKey { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates a color value that gets multiplied into blit operations
    /// </summary>
    /// <remarks>
    /// For implementation details see <see cref="SDL.SDL_GetSurfaceColorMod">SDL_GetSurfaceColorMod</see> and
    /// <see cref="SDL.SDL_SetSurfaceColorMod">SDL_SetSurfaceColorMod</see>
    /// </remarks>
    /// <exception cref="UnableToGetSurfaceColorModException">In case we are not able to get the surface's color mod</exception>
    /// <exception cref="UnableToSetSurfaceColorModException">In case we are not able to set the surface's color mod</exception>

    public Color? ColorMod { get; set; }

    /// <summary>
    /// Set up a surface for directly accessing the pixels.
    /// </summary>
    /// <exception cref="UnableToLockSurfaceException"></exception>
    public void Lock();

    /// <summary>
    /// Release a surface after directly accessing the pixels.
    /// </summary>
    public void Unlock();

    /// <summary>
    /// Sets or gets a value which indicates the alpha component to be multiplied in blit operations
    /// </summary>
    /// <remarks>For implementation details check <see cref="SDL.SDL_GetSurfaceAlphaMod"/>
    /// and <see cref="SDL.SDL_SetSurfaceAlphaMod"/></remarks>
    /// <exception cref="UnableToGetSurfaceAlphaModException"/>
    /// <exception cref="UnableToSetSurfaceAlphaModException"/>
    public byte AlphaMod { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates the surface's blend mode.
    /// </summary>
    /// <exception cref="UnableToGetSurfaceBlendModeException"></exception>
    /// <exception cref="UnableToSetSurfaceBlendModeException"></exception>
    public SDL.SDL_BlendMode BlendMode { get; set; }

    /// <summary>
    /// Gets or sets a value which indicates whether the surface is RLE-enabled.
    /// </summary>
    /// <exception cref="UnableToSetRLEException"></exception>
    public bool RLE { get; set; }

    /// <summary>
    /// Duplicates the current surface
    /// </summary>
    /// <returns></returns>
    /// <exception cref="UnableToDuplicateSurfaceException"></exception>
    public ISurface Duplicate();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    /// <exception cref="UnableToConvertSurfaceException"></exception>
    public ISurface Convert(uint format);
}
