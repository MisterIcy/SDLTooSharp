using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowFocusLostEventArgs : AbstractWindowEventArgs
{

    public WindowFocusLostEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.FocusLost )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.FocusLost,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
