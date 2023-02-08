namespace SDLTooSharp.Managed.Exception.Video.Surface;

public sealed class UnableToLockSurfaceException : SurfaceException
{
    public UnableToLockSurfaceException() : base("Unable to lock the surface")
    {
    }
}
