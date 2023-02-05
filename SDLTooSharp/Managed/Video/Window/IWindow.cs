using SDLTooSharp.Managed.Common;

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
    public bool Shown { get; set; }

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
    public bool Minimized { get; set; }
    
    /// <summary>
    /// Sets or gets a value that indicates whether the window is maximized
    /// </summary>
    public bool Maximized { get; set; }
    
    /// <summary>
    /// Sets or gets the Window's title.
    /// </summary>
    public string Title { get; set; }
}
