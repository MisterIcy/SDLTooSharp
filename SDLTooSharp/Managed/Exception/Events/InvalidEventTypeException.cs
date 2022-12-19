using SDLTooSharp.Managed.Events;

namespace SDLTooSharp.Managed.Exception.Events;

public sealed class InvalidEventTypeException : AbstractEventException
{
    public InvalidEventTypeException(EventType expected, EventType actual) : base(
        $"Invalid event: Expected {expected.ToString()} and got {actual.ToString()}")
    {

    }
}
