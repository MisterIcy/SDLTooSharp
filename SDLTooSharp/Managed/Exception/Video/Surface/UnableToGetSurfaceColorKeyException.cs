namespace SDLTooSharp.Managed.Exception.Video.Surface;

/// <summary>
/// Exception thrown when we are not able to get a surface's color key.
/// </summary>
public sealed class UnableToGetSurfaceColorKeyException : SurfaceException
{
    /// <summary>
    /// Creates a new <see cref="UnableToGetSurfaceColorKeyException"/>
    /// </summary>
    public UnableToGetSurfaceColorKeyException() : base("Unable to get the surface's color key")
    {
    }
}
