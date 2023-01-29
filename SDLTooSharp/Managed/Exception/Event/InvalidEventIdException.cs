namespace SDLTooSharp.Managed.Exception.Event;

public sealed class InvalidEventIdException : InvalidEventTypeException
{

    public InvalidEventIdException(string eventClass, uint expected, uint actual) : base(eventClass, expected, actual)
    {
    }
}
