using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;

public sealed class ApplicationDidEnterForegroundEventArgs : ApplicationEventArgs
{

    public ApplicationDidEnterForegroundEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.AppDidEnterForeground )
        {
            throw new InvalidEventTypeException(
                EventType.AppDidEnterForeground,
                EventType,
                ev
            );
        }
    }
}
