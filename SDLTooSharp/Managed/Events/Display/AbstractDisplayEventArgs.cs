using System.Diagnostics;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public abstract class AbstractDisplayEvent : AbstractEventArgs
{

    private uint display;
    private DisplayEventType _displayEventType;
    private int data;

    protected AbstractDisplayEvent(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.DisplayEvent )
        {
            throw new ArgumentException("Not a DisplayEvent", nameof(@event));
        }

        display = @event.Display.Display;
        _displayEventType = (DisplayEventType)@event.Display.Event;
        data = @event.Display.Data1;
    }

    public virtual uint GetDisplayId() => display;
    public virtual DisplayEventType GetEventType() => _displayEventType;
    public virtual int GetEventData() => data;
}
