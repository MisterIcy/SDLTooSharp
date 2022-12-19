using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowEnterEventArgs : AbstractWindowEventArgs
{

    public WindowEnterEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Enter )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Enter,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
