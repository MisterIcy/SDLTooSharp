namespace SDLTooSharp.Managed.Exception.Video.Window;

/// <summary>
/// Exception thrown when we cannot create an SDL Window
/// </summary>
public sealed class UnableToCreateWindowException: WindowException
{
    /// <summary>
    /// Creates a new <see cref="UnableToCreateWindowException"/>
    /// </summary>
    /// <remarks>In order to determine what went wrong, see <see cref="SDLException.SdlErrorMsg"/></remarks>
    public UnableToCreateWindowException() : base("Unable to create a window!")
    {
    }
}
