namespace SDLTooSharp.Managed.Exception.Display;

public sealed class UnableToGetDisplayDpiException : AbstractDisplayException
{

    public UnableToGetDisplayDpiException() : base("Unable to query the display's DPI")
    {
    }
}
