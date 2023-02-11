namespace SDLTooSharp.Managed.Exception.Video.Renderer;

/// <summary>
/// Thrown when we cannot get the renderer's blend mode.
/// </summary>
public sealed class UnableToGetBlendModeException : RendererException
{

    /// <summary>
    /// 
    /// </summary>
    public UnableToGetBlendModeException() : base("Unable to get the renderer's current blend mode")
    {
    }
}
