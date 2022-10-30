using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;
[ExcludeFromCodeCoverage]
public sealed class ApplicationLowMemoryEventArgs : ApplicationEventArgs
{

    public ApplicationLowMemoryEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.AppLowMemory )
        {
            throw new InvalidEventTypeException(
                EventType.AppLowMemory,
                EventType,
                ev
            );
        }
    }
}
