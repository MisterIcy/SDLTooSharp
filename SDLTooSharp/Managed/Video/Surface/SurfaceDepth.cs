namespace SDLTooSharp.Managed.Video.Surface;

/// <summary>
/// Enumeration for a <see cref="SDLSurface"/> Depth
/// </summary>
public enum SurfaceDepth : int
{
    /// <summary>
    /// 1 bits per pixel (black/white)
    /// </summary>
    D1BPP = 1,

    /// <summary>
    /// 4 bits per pixel (indexed, via palette)
    /// </summary>
    D4BPP = 4,

    /// <summary>
    /// 8 bits per pixel (indexed, via palette)
    /// </summary>
    D8BPP = 8,

    /// <summary>
    /// 16 bits per pixel
    /// </summary>
    D16BPP = 16,

    /// <summary>
    /// 24 bits per pixel
    /// </summary>
    D24BPP = 24,

    /// <summary>
    /// 32 bits per pixel
    /// </summary>
    D32BPP = 32
}
