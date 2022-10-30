using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;

public sealed class ApplicationDidEnterBackgroundEventArgs : ApplicationEventArgs
{

    public ApplicationDidEnterBackgroundEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.AppDidEnterBackground )
        {
            throw new InvalidEventTypeException(
                EventType.AppDidEnterBackground,
                EventType,
                ev
            );
        }
    }
}
