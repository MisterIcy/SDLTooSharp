using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;

public class ApplicationWillEnterForegroundEventArgs : ApplicationEventArgs
{

    public ApplicationWillEnterForegroundEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.AppWillEnterForeground )
        {
            throw new InvalidEventTypeException(
                EventType.AppWillEnterForeground,
                EventType,
                ev
            );
        }
    }
}
