namespace SDLTooSharp.Managed.Exception.Video.Surface;

/// <summary>
/// 
/// </summary>
public sealed class UnableToSetRLEException : SurfaceException
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="enable"></param>
    public UnableToSetRLEException(bool enable) : base($"Unable to {( enable ? "enable" : "disable" )} RLE")
    {
    }
}
