namespace SDLTooSharp.Managed.Exception.Events;

public abstract class AbstractEventException : System.Exception
{
    protected AbstractEventException(string message) : base(message)
    {

    }
}
