using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

public sealed class QuitEventArgs : AbstractEventArgs
{
    public QuitEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( ev.Type != (uint)EventType.Quit )
        {
            throw new InvalidEventTypeException(
                EventType.Quit,
                (EventType)ev.Type
            );
        }
    }
}
