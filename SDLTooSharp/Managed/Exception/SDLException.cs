namespace SDLTooSharp.Managed.Exception;

public abstract class SDLException : System.Exception
{
    protected SDLException(string message) : base(message)
    {

    }
}
