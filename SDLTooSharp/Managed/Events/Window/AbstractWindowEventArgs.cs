using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public abstract class AbstractWindowEventArgs : AbstractEventArgs
{

    public WindowEventType WindowEventType { get; }
    public uint WindowId { get; }
    public int Data1 { get; }
    public int Data2 { get; }

    public AbstractWindowEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.WindowEvent )
        {
            throw new InvalidEventTypeException(
                EventType.WindowEvent,
                (EventType)@event.Type
            );
        }

        WindowEventType = (WindowEventType)@event.Window.Event;
        WindowId = @event.Window.WindowID;
        Data1 = @event.Window.Data1;
        Data2 = @event.Window.Data2;
    }
}
