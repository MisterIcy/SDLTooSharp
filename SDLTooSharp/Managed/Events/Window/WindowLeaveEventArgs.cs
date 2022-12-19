using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowLeaveEventArgs : AbstractWindowEventArgs
{

    public WindowLeaveEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Leave )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Leave,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
