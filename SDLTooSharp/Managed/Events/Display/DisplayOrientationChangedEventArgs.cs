using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayOrientationChangedEventArgs : AbstractDisplayEvent
{
    public DisplayOrientation DisplayOrientation => (DisplayOrientation)Data;

    public DisplayOrientationChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Display.Event != (byte)( DisplayEventType.OrientationChanged ) )
        {
            throw new InvalidDisplaySubtypeEventException(
                DisplayEventType.OrientationChanged,
                (DisplayEventType)@event.Display.Event
            );
        }
    }
}
