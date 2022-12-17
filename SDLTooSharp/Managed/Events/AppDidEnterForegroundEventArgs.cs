using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public sealed class AppDidEnterForegroundEventArgs : AbstractEventArgs
{

    public AppDidEnterForegroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppDidEnterForeground )
        {
            throw new ArgumentException("Not an AppDidEnterForeground event", nameof(@event));
        }
    }
}
