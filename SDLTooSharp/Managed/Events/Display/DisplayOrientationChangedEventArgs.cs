using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayOrientationChangedEventArgs : AbstractDisplayEvent
{

    public DisplayOrientationChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Display.Event != (byte)( DisplayEventType.OrientationChanged ) )
        {
            throw new ArgumentException("Not an OrientationChanged event", nameof(@event));
        }
    }

    public DisplayOrientation GetDisplayOrientation() => (DisplayOrientation)GetEventData();
    private new int GetEventData()
    {
        return base.GetEventData();
    }
}
