namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown when we cannot get the renderer's output size
/// </summary>
public sealed class UnableToGetRendererOutputSizeException : RendererException
{

    /// <summary>
    /// Creates a new <see cref="UnableToGetRendererOutputSizeException"/>
    /// </summary>
    public UnableToGetRendererOutputSizeException() : base("Unable to get the renderer's output size")
    {
    }
}
