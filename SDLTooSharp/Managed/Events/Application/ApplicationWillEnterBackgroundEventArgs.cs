using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Application;
[ExcludeFromCodeCoverage]
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
