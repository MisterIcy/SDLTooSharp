namespace SDLTooSharp.Managed.Exception.Video.Texture;

/// <summary>
/// Basis for texture exceptions
/// </summary>
public abstract class TextureException : SDLException
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    protected TextureException(string message) : base(message)
    {
    }
}
