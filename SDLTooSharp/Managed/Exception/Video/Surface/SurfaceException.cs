namespace SDLTooSharp.Managed.Exception.Video.Surface;

/// <summary>
/// Abstract exception for surface errors.
/// </summary>
public abstract class SurfaceException : SDLException
{
    /// <summary>
    /// Creates a new <see cref="SurfaceException"/>
    /// </summary>
    /// <param name="message"></param>
    protected SurfaceException(string message) : base(message)
    {
    }
}
