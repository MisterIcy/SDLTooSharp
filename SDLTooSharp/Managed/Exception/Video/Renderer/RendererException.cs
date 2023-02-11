namespace SDLTooSharp.Managed.Exception.Video.Renderer;

public abstract class RendererException : SDLException
{
    protected RendererException(string message) : base(message)
    {
    }
}
