namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown in case we cannot set integer scale to the renderer.
/// </summary>
public sealed class UnableToSetIntegerScaleException : RendererException
{

    /// <summary>
    /// Creates a new <see cref="UnableToSetIntegerScaleException"/>
    /// </summary>
    public UnableToSetIntegerScaleException() : base("Unable to enable/disable integer scale on the renderer")
    {
    }
}
