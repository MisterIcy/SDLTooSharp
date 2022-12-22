namespace SDLTooSharp.Managed.Events;

public interface ISDLEvent
{
    /// <summary>
    /// The type of the event.
    /// </summary>
    public EventType Type { get; }
    
    /// <summary>
    /// The SDL-timestamp when the event occurred
    /// </summary>
    public uint Timestamp { get; }
}
