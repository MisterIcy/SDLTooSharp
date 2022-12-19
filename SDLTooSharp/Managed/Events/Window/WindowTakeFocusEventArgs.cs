using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowTakeFocusEventArgs : AbstractWindowEventArgs
{

    public WindowTakeFocusEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.TakeFocus )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.TakeFocus,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
