namespace SDLTooSharp.Managed.Video.Surface;

/// <summary>
/// Enumeration for a <see cref="SDLSurface"/> Depth
/// </summary>
public enum SurfaceDepth : int
{
    /// <summary>
    /// 1 bits per pixel (black/white)
    /// </summary>
    Depth1BitPerPixel = 1,

    /// <summary>
    /// 4 bits per pixel (indexed, via palette)
    /// </summary>
    Depth4BitPerPixel = 4,

    /// <summary>
    /// 8 bits per pixel (indexed, via palette)
    /// </summary>
    Depth8BitPerPixel = 8,

    /// <summary>
    /// 16 bits per pixel
    /// </summary>
    Depth16BitPerPixel = 16,

    /// <summary>
    /// 24 bits per pixel
    /// </summary>
    Depth24BitPerPixel = 24,

    /// <summary>
    /// 32 bits per pixel
    /// </summary>
    Depth32BitPerPixel = 32
}
