namespace SDLTooSharp.Managed.Exception.Event;

/// <summary>
/// Parent class for all Managed Event Exceptions
/// </summary>
public abstract class AbstractEventException : System.Exception
{
    /// <summary>
    /// Creates a new AbstractEventException
    /// </summary>
    /// <param name="message">The message of the exception</param>
    protected AbstractEventException(string message) : base(message)
    {
    }
}
