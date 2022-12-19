using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowMaximizedEventArgs : AbstractWindowEventArgs
{

    public WindowMaximizedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Maximized )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Maximized,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
