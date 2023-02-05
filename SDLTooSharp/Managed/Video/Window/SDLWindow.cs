using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception;
using SDLTooSharp.Managed.Exception.Video.Window;

namespace SDLTooSharp.Managed.Video.Window;

/// <summary>
/// Describes a window created by SDL
/// </summary>
public class SDLWindow : IWindow, IDisposable
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
    /// <exception cref="WindowMinimumSizeException">When attempting to set a size that violates the Window's <see cref="MinimumSize"/></exception>
    /// <exception cref="WindowMaximumSizeException">When attempting to set a size that violates the Window's <see cref="MaximumSize"/></exception>
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
                throw new WindowMinimumSizeException();
            }

            if ( maxSize is not null && ( value.Width > maxSize.Width || value.Height > maxSize.Height ) )
            {
                throw new WindowMaximumSizeException();
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
    /// <exception cref="UnableToChangeFullscreenModeException">When we cannot change the current fullscreen mode of the window</exception>
    public WindowMode Mode
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);
            if ( ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN ) ==
                 (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN )
            {
                _mode = WindowMode.Fullscreen;
                return _mode;
            }

            if ( ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP ) ==
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
                throw new UnableToChangeFullscreenModeException(value);
            }

            _mode = value;
        }
    }

    private bool _shown;

    /// <inheritdoc cref="IWindow.Shown"/>
    public bool Shown
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);

            _shown = ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN ) !=
                     (uint)SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN;

            return _shown;
        }
        set {
            if ( value == _shown )
            {
                return;
            }

            if ( value == false )
            {
                SDL.SDL_HideWindow(WindowPtr);
            } else
            {
                SDL.SDL_ShowWindow(WindowPtr);
            }

            _shown = value;
        }
    }

    public bool _decorated;

    /// <inheritdoc cref="IWindow.Decorated"/>
    public bool Decorated
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);
            _decorated = ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS ) !=
                         (uint)SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS;

            return _decorated;
        }
        set {
            if ( _decorated == value )
            {
                return;
            }

            SDL.SDL_SetWindowBordered(WindowPtr, value);

            _decorated = true;
        }
    }

    private bool _resizable;

    /// <inheritdoc cref="IWindow.Resizable"/>
    public bool Resizable
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);
            _resizable = ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE ) ==
                         (uint)SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE;

            return _resizable;
        }
        set {
            if ( _resizable == value )
            {
                return;
            }

            SDL.SDL_SetWindowResizable(WindowPtr, value);
            _resizable = value;
        }
    }

    private bool _minimized;

    /// <see cref="IWindow.Minimized"/>
    public bool Minimized
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);
            _minimized = ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED ) ==
                         (uint)SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED;

            return _minimized;
        }
        set {
            if ( _minimized == value )
            {
                return;
            }

            if ( value )
            {
                SDL.SDL_MinimizeWindow(WindowPtr);
            } else
            {
                SDL.SDL_RestoreWindow(WindowPtr);
            }

            _minimized = value;
        }
    }

    private bool _maximized;

    /// <inheritdoc cref="IWindow.Maximized"/>
    public bool Maximized
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);
            _maximized = ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED ) ==
                         (uint)SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED;

            return _maximized;
        }
        set {
            if ( _maximized == value )
            {
                return;
            }

            if ( value )
            {
                SDL.SDL_MaximizeWindow(WindowPtr);
            } else
            {
                SDL.SDL_RestoreWindow(WindowPtr);
            }

            _maximized = value;
        }
    }

    private string _title;

    /// <inheritdoc cref="Title"/>
    public string Title
    {
        get {
            _title = SDL.SDL_GetWindowTitle(WindowPtr);
            return _title;
        }
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
    /// <exception cref="UnableToCreateWindowException">In case we cannot create the window. See <see cref="SDLException.SdlErrorMsg"/> in order to determine what went wrong</exception>
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
            throw new UnableToCreateWindowException();
        }

        // Initialize Properties
        _title = title;
        _position = position;
        _size = dimensions;
        _minimumSize = null;
        _maximumSize = null;
        _mode = WindowMode.Windowed;
        _shown = true;
        _decorated = true;
        _resizable = false;
        _minimized = false;
        _maximized = false;
    }

    ~SDLWindow()
    {
        Dispose(false);
    }

    private void ReleaseUnmanagedResources()
    {
        if ( WindowPtr != IntPtr.Zero )
        {
            SDL.SDL_DestroyWindow(WindowPtr);
            WindowPtr = IntPtr.Zero;
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
}
