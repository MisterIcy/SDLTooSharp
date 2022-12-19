using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowResizedEventArgs : AbstractWindowEventArgs
{

    public WindowResizedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Resized )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Resized,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
