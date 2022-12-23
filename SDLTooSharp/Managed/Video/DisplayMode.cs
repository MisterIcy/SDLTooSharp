using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Display;

namespace SDLTooSharp.Managed.Video;
/// <summary>
/// Defines a DisplayMode
/// </summary>
public class DisplayMode
{
    /// <summary>
    /// Gets the pixel format as an encoded unsigned integer
    /// </summary>
    public uint PixelFormat { get; }
    /// <summary>
    /// Gets the width of the display.
    /// </summary>
    public int Width { get; }
    /// <summary>
    /// Gets the height of the display.
    /// </summary>
    public int Height { get; }
    /// <summary>
    /// Gets the refresh rate of the display.
    /// </summary>
    public int RefreshRate { get; }

    /// <summary>
    /// Gets a <see cref="Size"/> object containing the display's width and height.
    /// </summary>
    public Size Size => new Size(Width, Height);

    /// <summary>
    /// Gets the pixel format's name as reported by SDL
    /// </summary>
    public string PixelFormatName => SDL.SDL_GetPixelFormatName(PixelFormat);

    /// <summary>
    /// Creates a new Display Mode.
    /// </summary>
    /// <param name="mode"></param>
    public DisplayMode(SDL.SDL_DisplayMode mode)
    {
        PixelFormat = mode.Format;
        Width = mode.W;
        Height = mode.H;
        RefreshRate = mode.RefreshRate;
    }

    /// <summary>
    /// Creates a new display mode for a display and a particular display mode index.
    /// </summary>
    /// <param name="displayIndex"></param>
    /// <param name="modeIndex"></param>
    /// <exception cref="UnableToGetDisplayModeException"></exception>
    public DisplayMode(int displayIndex, int modeIndex)
    {
        int result = SDL.SDL_GetDisplayMode(displayIndex, modeIndex, out SDL.SDL_DisplayMode mode);
        if ( result != 0 )
        {
            throw new UnableToGetDisplayModeException();
        }

        PixelFormat = mode.Format;
        Width = mode.W;
        Height = mode.H;
        RefreshRate = mode.RefreshRate;
    }
    
    public static explicit operator SDL.SDL_DisplayMode(DisplayMode mode)
    {
        SDL.SDL_DisplayMode disp = default;
        disp.Format = mode.PixelFormat;
        disp.W = mode.Width;
        disp.H = mode.Height;
        disp.RefreshRate = mode.RefreshRate;

        return disp;
    }

    public static explicit operator DisplayMode(SDL.SDL_DisplayMode mode)
    {
        return new DisplayMode(mode);
    }
}
