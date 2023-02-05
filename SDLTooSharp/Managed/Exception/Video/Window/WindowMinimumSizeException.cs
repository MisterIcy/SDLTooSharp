using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Exception.Video.Window;
/// <summary>
/// Exception thrown when trying to set a Window's <see cref="IWindow.Size"/> but the value contains
/// at least one dimension that is lower than the respective dimension of <see cref="IWindow.MinimumSize"/>
/// </summary>
public sealed class WindowMinimumSizeException : WindowException
{
    private new string SdlErrorMsg => "";

    /// <summary>
    /// Creates a new <see cref="WindowMinimumSizeException"/>
    /// </summary>
    public WindowMinimumSizeException() : base("The specified size has at least one dimension lower than the window's minimum size")
    {
    }
}
