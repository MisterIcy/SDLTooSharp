using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Display;
[ExcludeFromCodeCoverage]
public abstract class DisplayEventArgs : CommonEventArgs
{
    public DisplayEventType DisplayEventType { get; }

    public uint DisplayID { get; }

    public int Data1 { get; }

    protected DisplayEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.DisplayEvent )
        {
            throw new InvalidEventTypeException(
                EventType.DisplayEvent,
                EventType,
                ev
            );
        }

        DisplayEventType = (DisplayEventType)ev.Display.Event;
        DisplayID = ev.Display.Display;
        Data1 = ev.Display.Data1;
    }
}
