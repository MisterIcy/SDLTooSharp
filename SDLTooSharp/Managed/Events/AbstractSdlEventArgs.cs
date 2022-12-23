using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public abstract class AbstractSdlEventArgs : EventArgs, ISdlEvent
{
    public EventType Type { get; protected set; }
    public uint Timestamp { get; protected set; }
    protected AbstractSdlEventArgs(SDL.SDL_Event ev)
    {
        Type = (EventType)ev.Common.Type;
        Timestamp = ev.Common.Timestamp;
    }
}
