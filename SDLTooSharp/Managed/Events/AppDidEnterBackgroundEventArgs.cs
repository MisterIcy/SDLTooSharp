using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public sealed class AppDidEnterBackgroundEventArgs : AbstractEventArgs
{

    public AppDidEnterBackgroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppDidEnterBackground )
        {
            throw new ArgumentException("Not an AppDidEnterBackground event", nameof(@event));
        }
    }
}
