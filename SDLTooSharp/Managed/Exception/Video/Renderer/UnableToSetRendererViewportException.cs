namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown in case we cannot set the renderer's viewport
/// </summary>
public sealed class UnableToSetRendererViewportException : RendererException
{

    /// <summary>
    /// Creates a new <see cref="UnableToSetRendererViewportException"/>
    /// </summary>
    public UnableToSetRendererViewportException() : base("Unable to set the renderer's viewport")
    {
    }
}
