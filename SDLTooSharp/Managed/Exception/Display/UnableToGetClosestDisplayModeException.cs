namespace SDLTooSharp.Managed.Exception.Display;

public sealed class UnableToGetClosestDisplayModeException : AbstractDisplayException
{

    public UnableToGetClosestDisplayModeException() : base("Unable to get the closest display mode to the one specified")
    {
    }
}
