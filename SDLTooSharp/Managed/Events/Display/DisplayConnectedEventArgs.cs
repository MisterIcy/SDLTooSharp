using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayConnectedEventArgs : AbstractDisplayEvent
{

    public DisplayConnectedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Display.Event != (byte)DisplayEventType.Connected )
        {
            throw new InvalidDisplaySubtypeEventException(
                DisplayEventType.Connected,
                (DisplayEventType)@event.Display.Event
            );
        }
    }
}
