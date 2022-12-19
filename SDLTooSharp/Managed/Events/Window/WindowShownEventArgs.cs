using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowShownEventArgs : AbstractWindowEventArgs
{
    public WindowShownEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Shown )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Shown,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
