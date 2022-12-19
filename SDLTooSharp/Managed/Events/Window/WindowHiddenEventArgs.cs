using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowHiddenEventArgs : AbstractWindowEventArgs
{

    public WindowHiddenEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Hidden )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Hidden,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
