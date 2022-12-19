using SDLTooSharp.Managed.Events.Window;

namespace SDLTooSharp.Managed.Exception.Events;

public sealed class InvalidWindowSubtypeEventException : AbstractEventException
{
    public InvalidWindowSubtypeEventException(WindowEventType expected, WindowEventType actual) : base(
        $"Invalid event: Expected {expected.ToString()} and got {actual.ToString()}")
    {

    }
}
