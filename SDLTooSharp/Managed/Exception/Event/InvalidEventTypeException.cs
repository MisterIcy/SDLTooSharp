using SDLTooSharp.Managed.Event;

namespace SDLTooSharp.Managed.Exception.Event;

/// <summary>
/// Exception thrown when an <see cref="AbstractSDLEventArgs"/> derived class is
/// being created with a different event type than the one it actually accepts.
/// </summary>
public class InvalidEventTypeException : AbstractEventException
{

    /// <summary>
    /// Creates a new exception object
    /// </summary>
    /// <param name="eventClass">The class we try to create</param>
    /// <param name="expected">The expected event type</param>
    /// <param name="actual">The actual event type</param>
    public InvalidEventTypeException(
        string eventClass,
        uint expected,
        uint actual
    ) : base($"You tried to create a {eventClass} with {actual} EventType, {expected} was expected")
    {
    }
}
