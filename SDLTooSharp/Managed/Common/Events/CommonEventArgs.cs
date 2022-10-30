using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Common.Events;

public abstract class CommonEventArgs
{
    /// <summary>
    /// Gets the event type.
    /// </summary>
    public EventType EventType { get; }

    /// <summary>
    /// Gets the timestamp describing when the event occurred.
    /// </summary>
    public uint Timestamp { get; }

    /// <summary>
    /// Creates a new CommonEventArgs object
    /// </summary>
    /// <param name="ev">The SDLEvent structure to get event info from</param>
    protected CommonEventArgs(SDL.SDL_Event ev)
    {
        EventType = (EventType)ev.Type;
        Timestamp = ev.Common.Timestamp;
    }
}
