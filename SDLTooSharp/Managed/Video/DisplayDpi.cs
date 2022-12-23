namespace SDLTooSharp.Managed.Video;

/// <summary>
/// Defines a display's DPI.
/// </summary>
public class DisplayDpi
{
    /// <summary>
    /// Diagonal DPI
    /// </summary>
    public float Diagonal { get; }

    /// <summary>
    /// Horizontal DPI
    /// </summary>
    public float Horizontal { get; }

    /// <summary>
    /// Vertical DPI
    /// </summary>
    public float Vertical { get; }

    public DisplayDpi(float ddpi, float hdpi, float vdpi)
    {
        Diagonal = ddpi;
        Horizontal = hdpi;
        Vertical = vdpi;
    }
}
