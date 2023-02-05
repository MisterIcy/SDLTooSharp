namespace SDLTooSharp.Managed.Exception.Video;
/// <summary>
/// Base exception class for Video subsystem related exceptions
/// </summary>
public abstract class VideoException : SDLException
{
    /// <summary>
    /// Creates a new <see cref="VideoException"/>
    /// </summary>
    /// <param name="message">A message that describes the error</param>
    protected VideoException(string message) : base(message)
    {
    }
}
