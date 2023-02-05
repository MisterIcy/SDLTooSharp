namespace SDLTooSharp.Managed.Exception.Video.Window;

/// <summary>
/// Base exception class for Window related exceptions
/// </summary>
public abstract class WindowException : VideoException
{
    /// <summary>
    /// Creates a new <see cref="WindowException"/>
    /// </summary>
    /// <param name="message">A message the describes the error.</param>
    protected WindowException(string message) : base(message)
    {
    }
}
