using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events.Video.Window;

namespace SDLTooSharp.Managed.Video.Window;

/// <summary>
/// Interface which describes a Window Object.
/// </summary>
public interface IWindow
{
    /// <summary>
    /// Sets or gets a value that indicates the windows position (top-left corner) in the screen.
    /// </summary>
    public Point2 Position { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates the window's current size in pixels.
    /// </summary>
    public Size Size { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates the minimum size of the window (i.e. the window's width or
    /// height cannot be lower that the respective values of <see cref="MinimumSize"/>).
    /// </summary>
    /// <remarks>In case you don't want to enforce a minimum size, leave this null</remarks>
    public Size? MinimumSize { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates the maximum size of the window (i.e. the window's width
    /// or height cannot be greater than the respective values of <see cref="MaximumSize"/>).
    /// </summary>
    /// <remarks>In case tou don't want to enforce a maximum size, leave this null</remarks>
    public Size? MaximumSize { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates the Window's current <see cref="WindowMode">Mode</see>.
    /// </summary>
    public WindowMode Mode { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates whether the window is Shown or not.
    /// </summary>
    public bool IsShown { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates whether the window is decorated.
    /// </summary>
    /// <remarks><i>Window Decoration</i> refers to the non-client area that
    /// includes the titlebar, borders, window buttons, etc.</remarks>
    public bool Decorated { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates whether the window can be resized.
    /// </summary>
    public bool Resizable { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates whether the window is minimized.
    /// </summary>
    public bool IsMinimized { get; set; }

    /// <summary>
    /// Sets or gets a value that indicates whether the window is maximized
    /// </summary>
    public bool IsMaximized { get; set; }

    /// <summary>
    /// Sets or gets the Window's title.
    /// </summary>
    public string Title { get; set; }

    #region Events

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> is shown.
    /// </summary>
    public event EventHandler<WindowShownEventArgsArgs> Shown;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> is hidden.
    /// </summary>
    public event EventHandler<WindowHiddenEventArgsArgs> Hidden;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> has been exposed and should be redrawn.
    /// </summary>
    public event EventHandler<WindowExposedEventArgs> Exposed;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> has been moved to a new <see cref="IWindow.Position"/>
    /// </summary>
    public event EventHandler<WindowMovedEventArgs> Moved;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> has been resized to a new <see cref="Size"/>
    /// </summary>
    public event EventHandler<WindowResizedEventArgs> Resized;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> has been resized. 
    /// </summary>
    /// <remarks>This event is followed by <see cref="Resized"/> if the <see cref="Size"/>
    /// of the <see cref="IWindow"/> has been changed by an external event.</remarks>
    public event EventHandler<WindowSizeChangedEventArgs> SizeChanged;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> is Minimized.
    /// </summary>
    public event EventHandler<WindowMinimizedEventArgs> Minimized;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> is Maximized.
    /// </summary>
    public event EventHandler<WindowMaximizedEventArgs> Maximized;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> gets restored after being
    /// either in the Minimized or the Maximized state.
    /// </summary>
    public event EventHandler<WindowRestoredEventArgs> Restored;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> gains the mouse's focus.
    /// </summary>
    public event EventHandler<WindowEnterEventArgs> Enter;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> loses the mouse's focus.
    /// </summary>
    public event EventHandler<WindowLeaveEventArgs> Leave;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> gains the keyboard's focus.
    /// </summary>
    public event EventHandler<WindowFocusGainedEventArgs> FocusGained;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> loses the keyboard's focus.
    /// </summary>
    public event EventHandler<WindowFocusLostEventArgs> FocusLost;

    /// <summary>
    /// Triggered when the Window Manager requests the <see cref="IWindow"/> to close
    /// </summary>
    public event EventHandler<WindowCloseEventArgs> Close;

    /// <summary>
    /// Triggered when the <see cref="IWindow"/> is offered the focus.
    /// </summary>
    public event EventHandler<WindowTakeFocusEventArgs> TakeFocus;

    // public event EventHandler<EventArgs> HitTest;
    // public event EventHandler<EventArgs> IccProfileChanged;
    /// <summary>
    /// Triggered when the <see cref="IWindow"/> is moved to another display
    /// </summary>
    public event EventHandler<WindowDisplayChangedEventArgs> DisplayChanged;

    #endregion
}
