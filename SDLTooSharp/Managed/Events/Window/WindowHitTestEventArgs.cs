using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowHitTestEventArgs : AbstractWindowEventArgs
{

    public WindowHitTestEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.HitTest )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.HitTest,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
