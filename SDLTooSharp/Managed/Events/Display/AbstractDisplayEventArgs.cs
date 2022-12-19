using System.Diagnostics;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Display;

public abstract class AbstractDisplayEvent : AbstractEventArgs
{

    public uint DisplayId { get; }
    public DisplayEventType DisplayEventType { get; }
    public int Data { get; }

    protected AbstractDisplayEvent(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.DisplayEvent )
        {
            throw new InvalidEventTypeException(
                EventType.DisplayEvent,
                (EventType)@event.Type
            );
        }

        DisplayId = @event.Display.Display;
        DisplayEventType = (DisplayEventType)@event.Display.Event;
        Data = @event.Display.Data1;
    }
}
