using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Video;

/// <summary>
/// Describes a DisplayMode
/// </summary>
public class DisplayMode
{
    /// <summary>
    /// Gets the width and the height of the display mode
    /// </summary>
    public Size Size { get; protected init; }

    /// <summary>
    /// Gets the Display Mode's format
    /// </summary>
    /// <remarks>See  <see cref="SDL.SDL_PixelFormatEnumToMasks"/></remarks>
    public uint Format { get; protected init; }

    /// <summary>
    /// Gets the name for the display mode's <see cref="Format"/>
    /// </summary>
    public string FormatName => SDL.SDL_GetPixelFormatName(Format);

    /// <summary>
    /// Gets the refresh rate in Hz
    /// </summary>
    public int RefreshRate { get; protected init; }

    /// <summary>
    /// Driver specific data.
    /// </summary>
    public IntPtr DriverData { get; protected init; }

    /// <summary>
    /// Creates a new display mode.
    /// </summary>
    /// <param name="mode">The <see cref="SDL.SDL_DisplayMode"/> structure to get data from</param>
    public DisplayMode(SDL.SDL_DisplayMode mode)
    {
        Size = new Size(mode.W, mode.H);
        Format = mode.Format;
        RefreshRate = mode.RefreshRate;
        DriverData = mode.DriverData;
    }

    /// <summary>
    /// Casts a <see cref="DisplayMode"/> to an SDL Structure
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static explicit operator SDL.SDL_DisplayMode(DisplayMode mode)
    {
        SDL.SDL_DisplayMode sdlMode = default;
        sdlMode.W = mode.Size.Width;
        sdlMode.H = mode.Size.Height;
        sdlMode.Format = mode.Format;
        sdlMode.RefreshRate = mode.RefreshRate;
        sdlMode.DriverData = mode.DriverData;

        return sdlMode;
    }

    /// <summary>
    /// Casts an <see cref="SDL.SDL_DisplayMode"/> structure to an DisplayMode object
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static implicit operator DisplayMode(SDL.SDL_DisplayMode mode)
    {
        return new DisplayMode(mode);
    }
}
