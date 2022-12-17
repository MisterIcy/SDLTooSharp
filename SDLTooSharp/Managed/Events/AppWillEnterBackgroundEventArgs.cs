using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public sealed class AppWillEnterBackgroundEventArgs : AbstractEventArgs
{

    public AppWillEnterBackgroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppWillEnterBackground )
        {
            throw new ArgumentException("Not an AppWillEnterBackground event", nameof(@event));
        }
    }
}
