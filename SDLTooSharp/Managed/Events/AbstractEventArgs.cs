using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public abstract class AbstractEventArgs : EventArgs, ISDLEvent
{
    /// <summary>
    /// The type of the event.
    /// </summary>
    public EventType Type
    {
        get;
    }

    /// <summary>
    /// The SDL-timestamp when the event occurred
    /// </summary>
    public uint Timestamp
    {
        get;
    }

    protected AbstractEventArgs(SDL.SDL_Event @event)
    {
        Type = (EventType)@event.Common.Type;
        Timestamp = @event.Common.Timestamp;
    }
}
