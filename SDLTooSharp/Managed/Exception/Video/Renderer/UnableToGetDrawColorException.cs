namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown when we cannot get the renderer's draw color
/// </summary>
public sealed class UnableToGetDrawColorException : RendererException
{

    /// <summary>
    /// 
    /// </summary>
    public UnableToGetDrawColorException() : base("Unable to get the renderer's draw color")
    {
    }
}
