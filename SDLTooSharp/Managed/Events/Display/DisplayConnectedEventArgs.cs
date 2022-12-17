using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayConnectedEventArgs : AbstractDisplayEvent
{

    public DisplayConnectedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Display.Event != (byte)DisplayEventType.Connected )
        {
            throw new ArgumentException("Not an DisplayConnected event", nameof(@event));
        }
    }

    /// <summary>
    /// Not supported in Connected Event
    /// </summary>
    /// <returns></returns>
    private new int GetEventData() => 0;
}
