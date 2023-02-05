using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Exception.Video.Window;
/// <summary>
/// Exception thrown when trying to set a Window's <see cref="IWindow.Size"/> but the value contains
/// at least one dimension that is greater than the respective dimension of <see cref="IWindow.MaximumSize"/>
/// </summary>
public sealed class WindowMaximumSizeException : WindowException
{
    /// <summary>
    /// Creates a new <see cref="WindowMaximumSizeException"/>
    /// </summary>
    public WindowMaximumSizeException() : base(
        "The specified size has at least one dimension greater than the window's maximum size")
    {
    }
}
