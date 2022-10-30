using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;

public sealed class ApplicationWillEnterBackgroundEventArgs : ApplicationEventArgs
{

    public ApplicationWillEnterBackgroundEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.AppWillEnterBackground )
        {
            throw new InvalidEventTypeException(
                EventType.AppWillEnterBackground,
                EventType,
                ev
            );
        }
    }
}
