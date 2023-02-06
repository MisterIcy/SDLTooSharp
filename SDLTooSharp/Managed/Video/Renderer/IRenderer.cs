namespace SDLTooSharp.Managed.Video.Renderer;

public interface IRenderer
{
    /// <summary>
    /// Clears the renderer
    /// </summary>
    public void Clear();

    /// <summary>
    /// Presents the renderer
    /// </summary>
    public void Present();
}
