namespace SDLTooSharp.Managed.Exception.Video.Surface;

/// <summary>
/// Exception thrown when we are not able to set a surface's color key
/// </summary>
public class UnableToSetSurfaceColorKeyException : SurfaceException
{
    /// <summary>
    /// Creates a new <see cref="UnableToSetSurfaceColorKeyException"/>
    /// </summary>
    public UnableToSetSurfaceColorKeyException() : base("Unable to set the surface's color key")
    {
    }
}
