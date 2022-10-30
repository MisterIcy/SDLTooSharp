using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;
[ExcludeFromCodeCoverage]
public sealed class QuitEventArgs : ApplicationEventArgs
{

    public QuitEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.Quit )
        {
            throw new InvalidEventTypeException(
                EventType.Quit,
                EventType,
                ev);
        }
    }
}
