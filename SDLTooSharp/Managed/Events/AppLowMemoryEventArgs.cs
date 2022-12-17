using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public sealed class AppLowMemoryEventArgs : AbstractEventArgs
{

    public AppLowMemoryEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppLowMemory )
        {
            throw new ArgumentException("Not an AppLowMemory event", nameof(@event));
        }
    }
}
