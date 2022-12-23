namespace SDLTooSharp.Managed.Exception.Display;

public sealed class NoDisplaysAvailableException : AbstractDisplayException
{
    public NoDisplaysAvailableException() : base("There are no displays attached")
    {
    }
}
