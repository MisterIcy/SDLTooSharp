using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowExposedEventArgs : AbstractWindowEventArgs
{

    public WindowExposedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Exposed )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Exposed,
                (WindowEventType)@event.Window.Type
            );
        }

    }
}
