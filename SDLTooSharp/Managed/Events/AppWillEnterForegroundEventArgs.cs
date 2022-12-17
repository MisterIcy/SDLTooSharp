using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public class AppWillEnterForegroundEventArgs : AbstractEventArgs
{

    public AppWillEnterForegroundEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppWillEnterForeground )
        {
            throw new ArgumentException("Not an AppWillEnterForeground event", nameof(@event));
        }
    }
}
