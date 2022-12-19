using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowCloseEventArgs : AbstractWindowEventArgs
{

    public WindowCloseEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Close )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Close,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
