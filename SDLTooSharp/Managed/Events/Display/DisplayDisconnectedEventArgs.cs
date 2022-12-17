using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayDisconnectedEventArgs : AbstractDisplayEvent
{

    public DisplayDisconnectedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Display.Event != (byte)DisplayEventType.Disconnected )
        {
            throw new ArgumentException("Not a DisplayDisconnected event", nameof(@event));
        }
    }

    /// <summary>
    /// Not supported in Disconnected Event
    /// </summary>
    /// <returns></returns>
    private new int GetEventData() => 0;
}
