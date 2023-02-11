namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown when we cannot set the renderer's draw color
/// </summary>
public sealed class UnableToSetDrawColorException : RendererException
{

    /// <summary>
    /// 
    /// </summary>
    public UnableToSetDrawColorException() : base("Unable to set the renderer's draw color")
    {
    }
}
