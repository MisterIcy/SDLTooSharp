using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Surface;

namespace SDLTooSharp.Managed.Video.Surface;
/// <summary>
/// Interface for surfaces
/// </summary>
public interface ISurface
{
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
    
    public void Lock();
    public void Unlock();


}
