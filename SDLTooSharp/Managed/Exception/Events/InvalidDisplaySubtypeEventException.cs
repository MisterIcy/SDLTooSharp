using SDLTooSharp.Managed.Events.Display;

namespace SDLTooSharp.Managed.Exception.Events;

public sealed class InvalidDisplaySubtypeEventException : AbstractEventException
{

    public InvalidDisplaySubtypeEventException(DisplayEventType expected, DisplayEventType actual) : base(
        $"Invalid event: Expected {expected.ToString()} and got {actual.ToString()}")
    {

    }
}
