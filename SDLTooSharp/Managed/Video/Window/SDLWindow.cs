using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Video.Window;

public class SDLWindow : IWindow
{
    /// <summary>
    /// Actual pointer to the SDL_Window* structure.
    /// </summary>
    public IntPtr WindowPtr { get; protected set; }

    private Point2 _position;

    /// <inheritdoc cref="IWindow.Position"/>
    public Point2 Position
    {
        get {
            SDL.SDL_GetWindowPosition(WindowPtr, out int x, out int y);
            if ( x != _position.X || y != _position.Y )
            {
                _position = new Point2(x, y);
            }

            return _position;
        }
        set {
            SDL.SDL_SetWindowPosition(WindowPtr, value.X, value.Y);
            _position = value;
        }
    }

    private Size _size;

    /// <inheritdoc cref="IWindow.Size"/>
    public Size Size
    {
        get {
            SDL.SDL_GetWindowSize(WindowPtr, out int w, out int h);
            if ( _size.Width != w || _size.Height != h )
            {
                _size = new Size(w, h);
            }

            return _size;
        }
        set {
            var minSize = MinimumSize;
            var maxSize = MaximumSize;

            if ( minSize is not null && ( value.Width < minSize.Width || value.Height < minSize.Height ) )
            {
                // TODO: Throw that size cannot be less than minimum size
            }

            if ( maxSize is not null && ( value.Width > maxSize.Width || value.Height > maxSize.Height ) )
            {
                // TODO: Throw that size cannot be greater than the maximum size
            }
            
            SDL.SDL_SetWindowSize(WindowPtr, value.Width, value.Height);
            _size = value;
        }
    }

    private Size? _minimumSize = null;

    /// <inheritdoc cref="IWindow.MinimumSize"/>
    public Size? MinimumSize
    {
        get {
            SDL.SDL_GetWindowMinimumSize(WindowPtr, out int w, out int h);
            if ( w == 0 && h == 0 )
            {
                return null;
            }

            if ( _minimumSize is null || _minimumSize.Width != w || _minimumSize.Height != h )
            {
                _minimumSize = new Size(w, h);    
            }
            
            return _minimumSize;
        }
        set {
            if ( value is not null )
            {
                SDL.SDL_SetWindowMinimumSize(WindowPtr, value.Width, value.Height);
            }

            _minimumSize = value;
        }
    }

    private Size? _maximumSize = null;
    
    /// <inheritdoc cref="IWindow.MaximumSize"/>
    public Size? MaximumSize
    {
        get {
            SDL.SDL_GetWindowMaximumSize(WindowPtr, out int w, out int h);
            if ( w == 0 && h == 0 )
            {
                return null;
            }

            if ( _maximumSize is null || _maximumSize.Width != w || _maximumSize.Height != h )
            {
                _maximumSize = new Size(w, h);    
            }
            
            return _maximumSize;
        }
        set {
            if ( value is not null )
            {
                SDL.SDL_SetWindowMaximumSize(WindowPtr, value.Width, value.Height);
            }

            _maximumSize = value;
        }
    }

    private WindowMode _mode;

    /// <inheritdoc cref="IWindow.Mode"/>
    public WindowMode Mode
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);
            if ( ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN ) ==
                 (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN )
            {
                _mode = WindowMode.Fullscreen;
                return _mode;
            } else if ( ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP ) ==
                        (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP )
            {
                _mode = WindowMode.DesktopFullscreen;
                return _mode;
            }

            _mode = WindowMode.Windowed;
            return _mode;
        }
        set {
            int result = value switch {
                WindowMode.Fullscreen => SDL.SDL_SetWindowFullscreen(WindowPtr,
                    (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN),
                WindowMode.DesktopFullscreen => SDL.SDL_SetWindowFullscreen(WindowPtr,
                    (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP),
                WindowMode.Windowed => SDL.SDL_SetWindowFullscreen(WindowPtr, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };

            if ( result != 0 )
            {
                // TODO: Cannot set fullscreen mode, throw
            }

            _mode = value;
        }
    }

    private bool _shown;
    /// <inheritdoc cref="IWindow.Shown"/>
    public bool Shown { get; set; }
    public bool Decorated { get; set; }
    public bool Resizable { get; set; }
    public bool Minimized { get; set; }
    public bool Maximized { get; set; }
    private string _title;

    /// <inheritdoc cref="Title"/>
    public string Title
    {
        get => _title;
        set {
            SDL.SDL_SetWindowTitle(WindowPtr, value);

            if ( SDL.SDL_GetWindowTitle(WindowPtr) != value )
            {
                // TODO: Throw
            }

            _title = value;
        }
    }

    /// <summary>
    /// Creates a new SDLWindow
    /// </summary>
    /// <param name="title">The window's title</param>
    /// <param name="position">The window's position</param>
    /// <param name="dimensions">The window's dimensions</param>
    public SDLWindow(string title, Point2 position, Size dimensions)
    {
        WindowPtr = SDL.SDL_CreateWindow(
            title,
            position.X,
            position.Y,
            dimensions.Width,
            dimensions.Height,
            (uint)SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
        );

        if ( WindowPtr == IntPtr.Zero )
        {
            // TODO: Throw proper exception
        }

        // Initialize Properties
        _title = title;
        _position = position;
        _size = dimensions;
        _minimumSize = null;
        _maximumSize = null;
        _mode = WindowMode.Windowed;
        _shown = true;
    }
}
