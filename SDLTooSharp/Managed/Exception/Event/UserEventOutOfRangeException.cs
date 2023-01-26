namespace SDLTooSharp.Managed.Exception.Event;

public sealed class UserEventOutOfRangeException : AbstractEventException
{
    /// <summary>
    /// Creates a new UserEventOutOfRangeException
    /// </summary>
    /// <param name="value">The type parameter of the event</param>
    public UserEventOutOfRangeException(uint value) : base(
        $"You have tried to create a User Event ({value}) which is out of range (0x8000 - 0xFFFF)")
    {
    }
}
