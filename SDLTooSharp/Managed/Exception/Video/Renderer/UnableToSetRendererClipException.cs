namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown in case we cannot set the renderer's clip
/// </summary>
public sealed class UnableToSetRendererClipException : RendererException
{
    /// <summary>
    /// Creates a new <see cref="UnableToSetRendererClipException"/>
    /// </summary>
    public UnableToSetRendererClipException() : base("Unable to set the renderer's clip rectangle")
    {
    }
}
