using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public abstract class AbstractEventArgs : EventArgs, ISDLEvent
{
    public EventType Type { get; }

    public uint Timestamp { get; }

    protected AbstractEventArgs(SDL.SDL_Event @event)
    {
        Type = (EventType)@event.Common.Type;
        Timestamp = @event.Common.Timestamp;
    }
}
