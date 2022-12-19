using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowRestoredEventArgs : AbstractWindowEventArgs
{

    public WindowRestoredEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Restored )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Restored,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
