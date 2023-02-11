namespace SDLTooSharp.Managed.Exception.Video.Renderer;

public sealed class DrawOperationFailedException : RendererException
{
    public DrawOperationFailedException(string operation) : base($"Draw operation {operation} failed.")
    {
    }
}
