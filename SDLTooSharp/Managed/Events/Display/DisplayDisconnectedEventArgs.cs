using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Display;

public sealed class DisplayDisconnectedEventArgs : AbstractDisplayEvent
{

    public DisplayDisconnectedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        throw new InvalidDisplaySubtypeEventException(
            DisplayEventType.Disconnected,
            (DisplayEventType)@event.Display.Event
        );
    }
}
