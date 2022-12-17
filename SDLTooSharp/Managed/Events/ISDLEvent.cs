namespace SDLTooSharp.Managed.Events;

public interface ISDLEvent
{
    public EventType GetType();
    public uint GetTimestamp();
}
