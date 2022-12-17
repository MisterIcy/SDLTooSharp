using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public sealed class AppTerminatingEventArgs : AbstractEventArgs
{

    public AppTerminatingEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.AppTerminating )
        {
            throw new ArgumentException("Not an AppTerminating Event", nameof(@event));
        }
    }
}
