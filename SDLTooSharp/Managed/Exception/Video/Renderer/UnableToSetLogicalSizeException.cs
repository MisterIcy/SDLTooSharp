namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown when we cannot set the renderer's logical size.
/// </summary>
public sealed class UnableToSetLogicalSizeException : RendererException
{

    /// <summary>
    /// Creates a new <see cref="UnableToSetLogicalSizeException"/>
    /// </summary>
    public UnableToSetLogicalSizeException() : base("Unable to set the renderer's logical size")
    {
    }
}
