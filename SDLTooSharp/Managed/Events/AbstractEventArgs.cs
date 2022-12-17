using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public abstract class AbstractEventArgs : EventArgs, ISDLEvent
{

    private EventType type;
    private uint timestamp;

    protected AbstractEventArgs(SDL.SDL_Event @event)
    {
        type = (EventType)@event.Common.Type;
        timestamp = @event.Common.Timestamp;
    }

    public new virtual EventType GetType() => type;
    public virtual uint GetTimestamp() => timestamp;
}
