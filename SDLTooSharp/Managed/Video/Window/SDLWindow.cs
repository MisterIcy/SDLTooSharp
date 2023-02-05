using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events.Video.Window;
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

    /// <inheritdoc cref="IWindow.IsShown"/>
    public bool IsShown
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
    public bool IsMinimized
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
    public bool IsMaximized
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
        if ( WindowPtr == IntPtr.Zero )
        {
            return;
        }

        SDL.SDL_DestroyWindow(WindowPtr);
        WindowPtr = IntPtr.Zero;
    }

    /// <inheritdoc cref="IDisposable.Dispose"/>
    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if ( disposing )
        {
        }
    }

    /// <inheritdoc cref="IDisposable.Dispose"/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Returns the index of the display containing the center of the window.
    /// </summary>
    public int DisplayIndex
    {
        get {
            int result = SDL.SDL_GetWindowDisplayIndex(WindowPtr);
            if ( result < 0 )
            {
                //TODO: Throw exception
            }

            return result;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating the window's current <see cref="DisplayMode"/>
    /// </summary>
    /// <remarks>Setting the display mode only has an effect when the window is in fullscreen</remarks>
    /// <exception cref="UnableToGetWindowDisplayModeException">When we cannot get the current display mode.</exception>
    /// <exception cref="UnableToSetWindowDisplayModeException">When we cannot set the display mode</exception>
    public DisplayMode DisplayMode
    {
        get {
            int result = SDL.SDL_GetWindowDisplayMode(WindowPtr, out var displayMode);
            if ( result != 0 )
            {
                throw new UnableToGetWindowDisplayModeException();
            }

            return displayMode;
        }
        set {
            if ( Mode != WindowMode.Fullscreen )
            {
                return;
            }

            int result = SDL.SDL_SetWindowDisplayMode(WindowPtr, (SDL.SDL_DisplayMode)value);
            if ( result != 0 )
            {
                throw new UnableToSetWindowDisplayModeException();
            }
        }
    }

    public uint PixelFormat
    {
        get {
            uint result = SDL.SDL_GetWindowPixelFormat(WindowPtr);
            if ( result == (uint)SDL.SDL_PixelFormatEnum.SDL_PIXELFORMAT_UNKNOWN )
            {
                //TODO: Throw an exception
            }

            return result;
        }
    }

    public string PixelFormatName => SDL.SDL_GetPixelFormatName(PixelFormat);

    public uint WindowId
    {
        get {
            uint result = SDL.SDL_GetWindowID(WindowPtr);
            if ( result == 0 )
            {
                //TODO: Throw
            }

            return result;
        }
    }

    /// <summary>
    /// Sets the window's icon
    /// </summary>
    /// <remarks>TODO: Properly refactor wish surface object</remarks>
    /// <param name="surfaceIcon"></param>
    public void SetIcon(IntPtr surfaceIcon)
    {
        SDL.SDL_SetWindowIcon(WindowPtr, surfaceIcon);
    }

    public Rectangle BorderSize
    {
        get {
            int result =
                SDL.SDL_GetWindowBordersSize(WindowPtr, out int top, out int left, out int bottom, out int right);
            if ( result != 0 )
            {
                //TODO: Throw an exception
            }

            return Rectangle.FromLTRB(left, top, right, bottom);
        }
    }

    public bool _alwaysOnTop;

    public bool AlwaysOnTop
    {
        get {
            uint flags = SDL.SDL_GetWindowFlags(WindowPtr);
            _alwaysOnTop = ( flags & (uint)SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP ) ==
                           (uint)SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP;

            return _alwaysOnTop;
        }
        set {
            if ( value == _alwaysOnTop )
            {
                return;
            }

            SDL.SDL_SetWindowAlwaysOnTop(WindowPtr, value);
            _alwaysOnTop = value;
        }
    }

    public void Raise()
    {
        SDL.SDL_RaiseWindow(WindowPtr);
    }

    /// <inheritdoc cref="IWindow.Shown"/>
    public event EventHandler<WindowShownEventArgsArgs>? Shown;

    /// <inheritdoc cref="IWindow.Hidden"/>
    public event EventHandler<WindowHiddenEventArgsArgs>? Hidden;

    /// <inheritdoc cref="IWindow.Exposed"/>
    public event EventHandler<WindowExposedEventArgs>? Exposed;

    /// <inheritdoc cref="IWindow.Moved"/>
    public event EventHandler<WindowMovedEventArgs>? Moved;

    /// <inheritdoc cref="IWindow.Resized"/>
    public event EventHandler<WindowResizedEventArgs>? Resized;

    /// <inheritdoc cref="IWindow.SizeChanged"/>
    public event EventHandler<WindowSizeChangedEventArgs>? SizeChanged;

    /// <inheritdoc cref="IWindow.Minimized"/>
    public event EventHandler<WindowMinimizedEventArgs>? Minimized;

    /// <inheritdoc cref="IWindow.Maximized"/>
    public event EventHandler<WindowMaximizedEventArgs>? Maximized;

    /// <inheritdoc cref="IWindow.Restored"/>
    public event EventHandler<WindowRestoredEventArgs>? Restored;

    /// <inheritdoc cref="IWindow.Enter"/>
    public event EventHandler<WindowEnterEventArgs>? Enter;

    /// <inheritdoc cref="IWindow.Leave"/>
    public event EventHandler<WindowLeaveEventArgs>? Leave;

    /// <inheritdoc cref="IWindow.FocusGained"/>
    public event EventHandler<WindowFocusGainedEventArgs>? FocusGained;

    /// <inheritdoc cref="IWindow.FocusLost"/>
    public event EventHandler<WindowFocusLostEventArgs>? FocusLost;

    /// <inheritdoc cref="IWindow.Close"/>
    public event EventHandler<WindowCloseEventArgs>? Close;

    /// <inheritdoc cref="IWindow.TakeFocus"/>
    public event EventHandler<WindowTakeFocusEventArgs>? TakeFocus;

    /// <inheritdoc cref="IWindow.DisplayChanged"/>
    public event EventHandler<WindowDisplayChangedEventArgs>? DisplayChanged;

    /// <summary>
    /// Handles an SDL Event
    /// </summary>
    /// <param name="ev">The event to be handled</param>
    public virtual void HandleEvent(SDL.SDL_Event ev)
    {
        if ( ev.Type != (uint)SDL.SDL_EventType.SDL_WINDOWEVENT )
        {
            return;
        }

        switch ( ev.Window.Event )
        {
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SHOWN:
                OnShown(new WindowShownEventArgsArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIDDEN:
                OnHidden(new WindowHiddenEventArgsArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_EXPOSED:
                OnExposed(new WindowExposedEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MOVED:
                OnMoved(new WindowMovedEventArgs(this, new Point2(ev.Window.Data1, ev.Window.Data2)));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED:
                OnResized(new WindowResizedEventArgs(this, new Size(ev.Window.Data1, ev.Window.Data2)));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED:
                OnSizeChanged(new WindowSizeChangedEventArgs(this, new Size(ev.Window.Data1, ev.Window.Data2)));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MINIMIZED:
                OnMinimized(new WindowMinimizedEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MAXIMIZED:
                OnMaximized(new WindowMaximizedEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESTORED:
                OnRestored(new WindowRestoredEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ENTER:
                OnEnter(new WindowEnterEventArgs(this));
                break;
                ;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_LEAVE:
                OnLeave(new WindowLeaveEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_GAINED:
                OnFocusGained(new WindowFocusGainedEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_LOST:
                OnFocusLost(new WindowFocusLostEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE:
                OnClose(new WindowCloseEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_TAKE_FOCUS:
                OnTakeFocus(new WindowTakeFocusEventArgs(this));
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIT_TEST:
                // Not implemented!
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ICCPROF_CHANGED:
                // Not implemented!
                break;
            case (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_DISPLAY_CHANGED:
                OnDisplayChanged(new WindowDisplayChangedEventArgs(this, (uint)ev.Window.Data1));
                break;
        }
    }

    protected virtual void OnShown(WindowShownEventArgsArgs args)
    {
        _shown = true;
        Shown?.Invoke(this, args);
    }

    protected virtual void OnHidden(WindowHiddenEventArgsArgs args)
    {
        _shown = false;
        Hidden?.Invoke(this, args);
    }

    protected virtual void OnExposed(WindowExposedEventArgs args)
    {
        Exposed?.Invoke(this, args);
    }

    protected virtual void OnMoved(WindowMovedEventArgs args)
    {
        _position = args.Position;
        Moved?.Invoke(this, args);
    }

    protected virtual void OnResized(WindowResizedEventArgs args)
    {
        _size = args.Dimensions;
        Resized?.Invoke(this, args);
    }

    protected virtual void OnSizeChanged(WindowSizeChangedEventArgs args)
    {
        _size = args.Dimensions;
        SizeChanged?.Invoke(this, args);
    }

    protected virtual void OnMinimized(WindowMinimizedEventArgs args)
    {
        _minimized = true;
        _maximized = false;
        Minimized?.Invoke(this, args);
    }

    protected virtual void OnMaximized(WindowMaximizedEventArgs args)
    {
        _minimized = false;
        _maximized = true;
        Maximized?.Invoke(this, args);
    }

    protected virtual void OnRestored(WindowRestoredEventArgs args)
    {
        _minimized = _maximized = false;
        Restored?.Invoke(this, args);
    }

    protected virtual void OnEnter(WindowEnterEventArgs args)
    {
        Enter?.Invoke(this, args);
    }

    protected virtual void OnLeave(WindowLeaveEventArgs args)
    {
        Leave?.Invoke(this, args);
    }

    protected virtual void OnFocusGained(WindowFocusGainedEventArgs args)
    {
        FocusGained?.Invoke(this, args);
    }

    protected virtual void OnFocusLost(WindowFocusLostEventArgs args)
    {
        FocusLost?.Invoke(this, args);
    }

    protected virtual void OnClose(WindowCloseEventArgs args)
    {
        Close?.Invoke(this, args);
    }

    protected virtual void OnTakeFocus(WindowTakeFocusEventArgs args)
    {
        TakeFocus?.Invoke(this, args);
    }

    protected virtual void OnDisplayChanged(WindowDisplayChangedEventArgs args)
    {
        DisplayChanged?.Invoke(this, args);
    }
}
