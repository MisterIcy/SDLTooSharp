using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;

public sealed class ApplicationTerminatingEventArgs : ApplicationEventArgs
{

    public ApplicationTerminatingEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.AppTerminating )
        {
            throw new InvalidEventTypeException(
                EventType.AppTerminating,
                EventType,
                ev);
        }
    }
}
