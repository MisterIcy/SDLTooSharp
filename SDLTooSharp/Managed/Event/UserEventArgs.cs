using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event;

[InternalEventChecks]
public abstract class UserEventArgs : AbstractSDLEventArgs
{
    protected UserEventArgs(SDL.SDL_Event evt) : base(evt)
    {
        if ( evt.Type is < (uint)SDL.SDL_EventType.SDL_USEREVENT or >= (uint)SDL.SDL_EventType.SDL_LASTEVENT )
        {
            throw new UserEventOutOfRangeException(evt.Type);
        }
    }
}
