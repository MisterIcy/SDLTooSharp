using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Exception;
using SDLTooSharp.Managed.Exception.Display;

namespace SDLTooSharp.Managed.Video;

/// <summary>
/// Defines a display
/// </summary>
public class Display
{
    /// <summary>
    /// Gets the display's identifier as reported by SDL
    /// </summary>
    public int DisplayId { get; }

    /// <summary>
    /// Gets the display's name
    /// </summary>
    public string Name => SDL.SDL_GetDisplayName(DisplayId);

    /// <summary>
    /// Gets the desktop area represented by the display
    /// </summary>
    /// <exception cref="UnableToGetDisplayBoundsException">If we are not able to get the display's bounds</exception>
    public Rectangle Bounds
    {
        get {
            int result = SDL.SDL_GetDisplayBounds(DisplayId, out SDL.SDL_Rect rect);
            if ( result != 0 )
            {
                throw new UnableToGetDisplayBoundsException();
            }

            return new Rectangle(
                rect.X, rect.Y, rect.W, rect.H
            );
        }
    }

    /// <summary>
    /// Gets the usable desktop area represented by the display
    /// </summary>
    /// <exception cref="UnableToGetDisplayBoundsException">If we are not able to get the display's usable bounds</exception>
    public Rectangle UsableBounds
    {
        get {
            int result = SDL.SDL_GetDisplayUsableBounds(DisplayId, out SDL.SDL_Rect rect);
            if ( result != 0 )
            {
                throw new UnableToGetDisplayBoundsException();
            }

            return new Rectangle(rect.X, rect.Y, rect.W, rect.H);
        }
    }

    /// <summary>
    /// Gets the dots/pixels per inch (dpi) for the display. 
    /// </summary>
    /// <exception cref="UnableToGetDisplayDpiException">In case we cannot query the display's dpi</exception>
    public DisplayDpi Dpi
    {
        get {
            int result = SDL.SDL_GetDisplayDPI(DisplayId, out float d, out float h, out float v);
            if ( result < 0 )
            {
                throw new UnableToGetDisplayDpiException();
            }

            return new DisplayDpi(d, h, v);
        }
    }

    /// <summary>
    /// Gets the orientation of the display
    /// </summary>
    public DisplayOrientation Orientation => (DisplayOrientation)SDL.SDL_GetDisplayOrientation(DisplayId);

    /// <summary>
    /// Gets the number of modes supported by this display.
    /// </summary>
    /// <exception cref="UnableToEnumerateDisplayModesException">In case we cannot enumerate the display's modes</exception>
    public int NumDisplayModes
    {
        get {
            int result = SDL.SDL_GetNumDisplayModes(DisplayId);
            if ( result <= 0 )
            {
                throw new UnableToEnumerateDisplayModesException();
            }

            return result;
        }
    }

    private List<DisplayMode> _modes;

    /// <summary>
    /// Gets a list of display modes available for this display.
    /// </summary>
    public List<DisplayMode> Modes => _modes;

    /// <summary>
    /// Gets the number of available displays.
    /// </summary>
    /// <returns>The number of available displays</returns>
    /// <exception cref="NoDisplaysAvailableException">If there are no displays attached to the system</exception>
    /// <exception cref="UnableToEnumerateDisplaysException">If we are not able to enumerate the displays of the system. See <see cref="SDLException.SdlErrorMsg"/> for more information.</exception>
    public static int NumDisplays
    {
        get {
            int result = SDL.SDL_GetNumVideoDisplays();

            return result switch {
                0 => throw new NoDisplaysAvailableException(),
                < 0 => throw new UnableToEnumerateDisplaysException(),
                _ => result
            };
        }
    }

    /// <summary>
    /// Gets the desktop display mode for this display.
    /// </summary>
    /// <exception cref="UnableToGetDisplayModeException"></exception>
    public DisplayMode Desktop
    {
        get {
            int result = SDL.SDL_GetDesktopDisplayMode(DisplayId, out SDL.SDL_DisplayMode mode);
            if ( result != 0 )
            {
                throw new UnableToGetDisplayModeException();
            }

            return new DisplayMode(mode);
        }
    }

    /// <summary>
    /// Gets the current display mode set for this display.
    /// </summary>
    /// <exception cref="UnableToGetDisplayModeException"></exception>
    public DisplayMode Current
    {
        get {
            int result = SDL.SDL_GetCurrentDisplayMode(DisplayId, out SDL.SDL_DisplayMode mode);
            if ( result != 0 )
            {
                throw new UnableToGetDisplayModeException();
            }

            return new DisplayMode(mode);
        }
    }

    /// <summary>
    /// Returns the display mode closest to the one supplied
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    /// <exception cref="UnableToGetClosestDisplayModeException"></exception>
    public DisplayMode GetClosest(DisplayMode mode)
    {
        IntPtr result = SDL.SDL_GetClosestDisplayMode(DisplayId, (SDL.SDL_DisplayMode)mode, out var closest);
        if ( result == IntPtr.Zero )
        {
            throw new UnableToGetClosestDisplayModeException();
        }

        return new DisplayMode(closest);
    }

    /// <summary>
    /// Creates a new display object
    /// </summary>
    /// <param name="displayIndex"></param>
    public Display(int displayIndex)
    {
        DisplayId = displayIndex;
        _modes = new List<DisplayMode>();
        for ( int i = 0; i < NumDisplayModes; i++ )
        {
            _modes.Add(new DisplayMode(DisplayId, i));
        }
    }

    /// <summary>
    /// Fired when a display is connected
    /// </summary>
    public static event EventHandler<DisplayConnectedEventArgs> Connected;

    /// <summary>
    /// Fired when a display is disconnected
    /// </summary>
    public static event EventHandler<DisplayDisconnectedEventArgs> Disconnected;

    /// <summary>
    /// Fired when the display's orientation has been changed.
    /// </summary>
    public event EventHandler<DisplayOrientationChangedEventArgs> OrientationChanged;
}
