namespace SDLTooSharp.Managed.Exception.Events;

public sealed class InvalidEventTypeException : AbstractEventException
{
    public InvalidEventTypeException(string expected, string actual) : base(
        $"Invalid event: Expected {expected} and got {actual}")
    {

    }
}
